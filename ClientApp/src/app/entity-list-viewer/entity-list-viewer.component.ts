import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError, first } from 'rxjs/operators';
import { forkJoin, Subscription } from 'rxjs';
import { GenericEntitiesService } from '../services/genericEntities.service';
import { GenericEntitySummary } from '../models/genericEntitySummary';

@Component({
  selector: 'app-entity-list-viewer',
  templateUrl: './entity-list-viewer.component.html'
})
export class EntityListViewerComponent {
  public entities: GenericEntitySummary[];
  public entityTypeName: string;
  public listName: string;
  public listActions: string[];
  private buttonClickedSubscription: Subscription;

  constructor(private route: ActivatedRoute, private genericEntitiesService: GenericEntitiesService) {
    this.handleButtonClicks();
  } 

  async ngOnInit() {
    const segments = await this.route.url.pipe(first()).toPromise();
    const params = await this.route.queryParams.pipe(first()).toPromise();
    let filter = '';
    if (params['filter']) filter = params['filter'];
    this.listName = segments[segments.length - 1].toString();
    this.entityTypeName = this.singularize(this.listName);
    
    const loadData = [this.genericEntitiesService.getEntitiesList(this.listName, filter),this.genericEntitiesService.getEntitiesListActions(this.entityTypeName)];
    forkJoin(loadData)
      .pipe()
      .subscribe(([entities,actions]) => {
        this.entities = <GenericEntitySummary[]>entities;
        this.listActions = <string[]>actions;
      });
  }

  private singularize(name: string): string {
    return name.endsWith('s') ? name.substring(0, name.length -1) : name;
  }

  handleButtonClicks() {
    this.buttonClickedSubscription = this.genericEntitiesService.headerButtonClicked.subscribe(buttonName => {
      this.genericEntitiesService.listAction(this.entityTypeName, buttonName)
        .subscribe(actionResult => { /* implement successful path*/ }, error => { /* implement error handling */ });
      });
  }

  ngOnDestroy() 
  {
    this.buttonClickedSubscription.unsubscribe();
  }  
}

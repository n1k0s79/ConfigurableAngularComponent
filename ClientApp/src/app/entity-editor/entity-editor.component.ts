import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';
import { GenericEntitiesService } from '../services/genericEntities.service';
import { GenericEntityDescriptor } from '../models/genericEntityDescriptor';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-entity-editor',
  templateUrl: './entity-editor.component.html',
  styleUrls: ['./entity-editor.component.css']
})
export class EntityEditorComponent {
  public entity: GenericEntityDescriptor;
  public entityTypeName = '';
  public id = 0;
  private buttonClickedSubscription: Subscription;

  constructor(private route: ActivatedRoute, private genericEntitiesService: GenericEntitiesService) {
    this.handleButtonClicks();
  }

  async ngOnInit() {
    const params = await this.route.queryParams.pipe(first()).toPromise();
    let layout = 'oneColumn';
    if (params['layout']) layout = params['layout']; // TODO: use layout query parameter to parameterize the layout of the controls

    const segments = await this.route.url.pipe(first()).toPromise();
    this.entityTypeName = segments[segments.length - 2].toString();
    this.id = Number(segments[segments.length - 1]);
    this.genericEntitiesService.getEntityDescriptor(this.entityTypeName, this.id)
      .subscribe(descriptor => this.entity = descriptor, error => { /* handle error */ });
  }

  handleButtonClicks() {
    this.buttonClickedSubscription = this.genericEntitiesService.headerButtonClicked.subscribe(buttonName => {
      this.genericEntitiesService.entityAction(this.entityTypeName, buttonName, this.id)
        .subscribe(actionResult => { /* implement successful path*/ }, error => { /* implement error handling */ });
      });
  }

  ngOnDestroy() {
    this.buttonClickedSubscription.unsubscribe();
  }  
}

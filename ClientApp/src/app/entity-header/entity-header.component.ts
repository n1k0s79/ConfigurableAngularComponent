import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input } from '@angular/core';
import { GenericEntitiesService } from '../services/genericEntities.service';

@Component({
  selector: 'app-entity-header',
  templateUrl: './entity-header.component.html',
  styleUrls: ['./entity-header.component.css']
})
export class EntityHeaderComponent {
  @Input() public actions: string[];
  @Input() public title: string;

  constructor(private genericEntitesServices: GenericEntitiesService) {
  } 

  public buttonClicked(buttonName: string) {
    this.genericEntitesServices.onHeaderButtonClick(buttonName);
  }
}

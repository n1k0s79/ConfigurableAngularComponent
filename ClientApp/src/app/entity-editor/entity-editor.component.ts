import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-entity-editor',
  templateUrl: './entity-editor.component.html'
})
export class EntityEditorComponent {
  public products: string[];
  public customers: Customer[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<string[]>(baseUrl + 'product').subscribe(result => {
      this.products = result;
    }, error => console.error(error));

    http.get<Customer[]>(baseUrl + 'customer').subscribe(result => {
      this.customers = result;
    }, error => console.error(error));
  }
}

interface Customer {
  Lastname: string;
  Firstname: string;
  Id: number;
}

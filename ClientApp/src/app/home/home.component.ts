import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public message = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
  } 

  public fillWithSampleData(): void {
    debugger;
    this.message = 'Filling DB with sample data...';
    this.http.post(`${this.baseUrl}genericEntitySummary`, null)
      .subscribe(result => this.message = 'OK', error => this.message = 'Failed');
  }
}

import { Injectable } from '@angular/core';
import { Observable, Subject, Subscription } from 'rxjs';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GenericEntitySummary} from '../models/genericEntitySummary';
import { GenericEntityDescriptor} from '../models/genericEntityDescriptor';

@Injectable()
export class GenericEntitiesService {
    private headerButtonClickedSubject: Subject<string>;
    public headerButtonClicked: Observable<string>;

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        debugger;
        this.headerButtonClickedSubject = new Subject<string>();
        this.headerButtonClicked = this.headerButtonClickedSubject.asObservable();
    }

    public onHeaderButtonClick(buttonName: string) {
        debugger;
        this.headerButtonClickedSubject.next(buttonName);
    }

    public entityAction(entityTypeName: string, actionName: string, id: number): Observable<object>
    {
        return this.http.post(`${this.baseUrl}genericEntityActions/entity?entityTypeName=${entityTypeName}&actionName=${actionName}&id=${id}`, null);
    }

    public listAction(entityTypeName: string, actionName: string): Observable<object>
    {
        return this.http.post(`${this.baseUrl}genericEntityActions/list?entityTypeName=${entityTypeName}&actionName=${actionName}`, null);
    }

    public getEntitiesList(listName: string, filter: string): Observable<GenericEntitySummary[]> 
    {
        return this.http.get<GenericEntitySummary[]>(`${this.baseUrl}genericEntitySummary?listName=${listName}&filter=${filter}`);
    }
    
    public getEntitiesListActions(entityTypeName: string): Observable<string[]> 
    {
        return this.http.get<string[]>(`${this.baseUrl}genericEntityActions?entityTypeName=${entityTypeName}`);
    }

    public getEntityDescriptor(entityTypeName: string, id: number): Observable<GenericEntityDescriptor>
    {
        return this.http.get<GenericEntityDescriptor>(`${this.baseUrl}genericEntity?entityTypeName=${entityTypeName}&id=${id}`);
    }
}
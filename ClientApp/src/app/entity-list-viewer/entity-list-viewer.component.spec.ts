import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Type } from '@angular/core';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { EntityListViewerComponent } from './entity-list-viewer.component';

describe('EntityListViewerComponent', () => {
  let component: EntityListViewerComponent;
  let fixture: ComponentFixture<EntityListViewerComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      declarations: [ EntityListViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EntityListViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Counter');
  }));

  it('should load query parameters', async(() => {
    // TODO implement
  }));

  // it('should send http request to get the list', async(() => {
  //   const dummyList: GenericEntitySummary[] = [      
  //   ];
  
  //   const request = httpMock.expectOne(`${url}/users`);
  //   request.flush(dummyList);
  
  //   expect(request.request.method).toBe('GET');
  //   expect(component.entities).toEqual(dummyList);  
  // }));

  it('should send http request to get the list', async(() => {
    // TODO implement
  }));
});




// describe('SendSmsComponent ', () => {
//   let fixture: ComponentFixture<SendSmsComponent>;
//   let app: SendSmsComponent;
//   let httpMock: HttpTestingController;

//   describe('SendSmsComponent ', () => {
//     beforeEach(async () => {
//       TestBed.configureTestingModule({
//         imports: [
//           HttpClientTestingModule,
//         ],
//         declarations: [
//           SendSmsComponent,
//         ],
//         providers: [
//           ApiService,
//         ],
//       });

//       await TestBed.compileComponents();

//       fixture = TestBed.createComponent(SendSmsComponent);
//       app = fixture.componentInstance;
//       httpMock = fixture.debugElement.injector.get<HttpTestingController>(HttpTestingController as Type<HttpTestingController>);

//       fixture.detectChanges();
//     });

//     afterEach(() => {
//       httpMock.verify();
//     });

//   });
// });

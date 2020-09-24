import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, UrlMatchResult, UrlSegment } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { EntityEditorComponent } from './entity-editor/entity-editor.component'
import { EntityListViewerComponent } from './entity-list-viewer/entity-list-viewer.component'
import { EntityHeaderComponent } from './entity-header/entity-header.component'
import { PathHelper } from './pathHelper';
import { GenericEntitiesService } from './services/genericEntities.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    EntityEditorComponent,
    EntityListViewerComponent,
    EntityHeaderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { component: EntityListViewerComponent, matcher: ListEntityUrlMatcher },
      { component: EntityEditorComponent, matcher: EditEntityUrlMatcher },
    ])
  ],
  providers: [GenericEntitiesService],
  bootstrap: [AppComponent]
})
export class AppModule { }

// note that the following functions must be exported
// Otherwise the build will fail with 'ERROR in Cannot read property 'loadChildren' of undefined'
export function ListEntityUrlMatcher(url: UrlSegment[]): UrlMatchResult {
  return PathHelper.StartsWith(url, [ 'list/' ])
    ? ({consumed: url}) : null;
  }
  
// note that the following functions must be exported
// Otherwise the build will fail with 'ERROR in Cannot read property 'loadChildren' of undefined'
export function EditEntityUrlMatcher(url: UrlSegment[]): UrlMatchResult {
  return PathHelper.StartsWith(url, [ 'view/' ])
    ? ({consumed: url}) : null;
  }


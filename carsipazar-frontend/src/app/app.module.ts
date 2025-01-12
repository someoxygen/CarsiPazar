import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
// import { ValueComponent } from './value/value.component';
import { NavComponent } from './nav/nav.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
// import { GalleryModule } from 'ng-gallery';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AlertifyService } from './services/alertify.service';
import { RegisterComponent } from './register/register.component';
// import { NgxEditorModule } from 'ngx-editor';
// import { FileUploadModule } from 'ng2-file-upload';
// import { PhotoComponent } from './photo/photo.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { NoteComponent } from './note/note.component';
// import { NoteDetailComponent } from './note/note-detail/note-detail.component';
// import { NoteAddComponent } from './note/note-add/note-add.component';

@NgModule({
  declarations: [					
    AppComponent,
    // ValueComponent,
    NavComponent,
    // NoteComponent,
    // NoteDetailComponent,
    // NoteAddComponent,
    RegisterComponent,
    //PhotoComponent
   ],
  imports: [
    // NgxEditorModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    //GalleryModule,
    FormsModule,
    ReactiveFormsModule,
    //FileUploadModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [
    AlertifyService,
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

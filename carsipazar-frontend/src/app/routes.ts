import { Routes } from '@angular/router';
// import { NoteComponent } from './note/note.component';
// import { ValueComponent } from './value/value.component';
// import { NoteDetailComponent } from './note/note-detail/note-detail.component';
// import { NoteAddComponent } from './note/note-add/note-add.component';
import { RegisterComponent } from './register/register.component';
// import { PhotoComponent } from './photo/photo.component';

export const appRoutes : Routes = [
//   { path: 'note', component: NoteComponent },
//   { path: 'value', component: ValueComponent },
//   { path: 'noteDetail/:noteId', component: NoteDetailComponent },
//   { path: 'noteadd/:operationName', component: NoteAddComponent },
//   { path: 'noteedit/:operationName', component: NoteAddComponent },
//   { path: 'addphoto/:cityId', component: PhotoComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: 'register', pathMatch: 'full' }
];

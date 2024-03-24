import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateListComponent } from './pages/candidate-list/candidate-list.component';
import { CandidateDetailComponent } from './pages/candidate-detail/candidate-detail.component';

const routes: Routes = [
  { path: '', component: CandidateListComponent },
  { path: 'candidate-detail/:id', component: CandidateDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

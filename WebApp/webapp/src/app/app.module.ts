import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TuiRootModule } from '@taiga-ui/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CandidateListComponent } from './pages/candidate-list/candidate-list.component';
import { CandidateDetailComponent } from './pages/candidate-detail/candidate-detail.component';
import { ConfigInterceptor } from './configs/http.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CandidateService } from './services/candidate.service';
import { InterviewerService } from './services/interviewer.service';
import { StoreModule } from '@ngrx/store';

@NgModule({
  declarations: [
    AppComponent,
    CandidateListComponent,
    CandidateDetailComponent
  ],
  imports: [
    BrowserAnimationsModule,
    TuiRootModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    StoreModule
],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ConfigInterceptor, multi: true },
    CandidateService,
    InterviewerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

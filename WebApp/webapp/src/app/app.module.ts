import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
import { CandidateCardComponent } from './pages/candidate-list/components/candidate-card/candidate-card.component';
import { CandidateColumnComponent } from './pages/candidate-list/components/candidate-column/candidate-column.component';
import { TuiCardModule, TuiIconModule } from '@taiga-ui/experimental';
import { TuiInputModule, TuiDataListWrapperModule, TuiSelectModule, TuiInputDateModule, TuiFieldErrorPipeModule, 
  TuiInputPhoneInternationalModule } from '@taiga-ui/kit';
import { TuiDataListModule, TuiButtonModule, TuiErrorModule, TuiLoaderModule, TuiAlertModule, TuiRootModule,
  TuiTextfieldControllerModule } from '@taiga-ui/core';
import { TuiTableModule } from '@taiga-ui/addon-table';
import { DebounceClickDirective } from './directives/debounce-click.directive';
import { TruncatePipe } from './pipes/truncate.pipe';
import { AppStoreModule } from './store';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    CandidateListComponent,
    CandidateDetailComponent,
    CandidateCardComponent,
    CandidateColumnComponent,
    DebounceClickDirective,
    TruncatePipe
  ],
  imports: [
    BrowserAnimationsModule,
    TuiRootModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    StoreModule,
    TuiCardModule,
    TuiIconModule,
    TuiInputModule,
    TuiDataListModule,
    TuiDataListWrapperModule,
    TuiSelectModule,
    TuiInputDateModule,
    TuiButtonModule,
    TuiErrorModule,
    TuiLoaderModule,
    TuiAlertModule,
    TuiFieldErrorPipeModule,
    TuiInputPhoneInternationalModule,
    TuiTableModule,
    AppStoreModule,
    HttpClientModule,
    TuiTextfieldControllerModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ConfigInterceptor, multi: true },
    CandidateService,
    InterviewerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

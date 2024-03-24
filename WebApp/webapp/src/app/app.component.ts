import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './store/state';
import { SelectIsLoading } from './store/selectors';
import { Subject, takeUntil } from 'rxjs';
import { getCandidates, getInterviewers } from './store/actions';
import { CandidateFilterModel } from './models/output/get-candidate-filter.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  constructor(private readonly store$: Store<AppState>) {}

  isLoading: boolean = true;
  destroySubject$: Subject<boolean> = new Subject();

  ngOnInit(): void {
    this.store$.dispatch(getInterviewers());
    this.store$.dispatch(getCandidates({ payload: new CandidateFilterModel() }));

    this.store$.select(SelectIsLoading).pipe(
      takeUntil(this.destroySubject$)
    ).subscribe(data => {
      this.isLoading = data;
    });
  }

  ngOnDestroy(): void {
    this.destroySubject$.next(true);
    this.destroySubject$.complete();
  }

  get loader() {
    return this.isLoading;
  }
}

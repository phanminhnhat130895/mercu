import { Component, OnDestroy, OnInit } from "@angular/core";
import { tuiItemsHandlersProvider } from '@taiga-ui/kit';
import { InterviewerModel } from "../../models/input/interviewer.model";
import { CandidateFilterModel } from "../../models/output/get-candidate-filter.model";
import { TuiDay } from '@taiga-ui/cdk';
import { CandidateStatusEnum } from "../../common/enums/CandidateStatusEnum";
import { Subject, debounceTime, takeUntil } from 'rxjs';
import { Store } from "@ngrx/store";
import { AppState } from "src/app/store/state";
import { getCandidates } from "src/app/store/actions";
import { SelectInterviewers } from "src/app/store/selectors";
import { FormControl, FormGroup } from "@angular/forms";

@Component({
    selector: 'app-cadidate-list',
    templateUrl: './candidate-list.component.html',
    providers: [
        tuiItemsHandlersProvider({
            stringify: (item: InterviewerModel) => `${item.firstName} ${item.lastName}`,
        }),
    ],
})
export class CandidateListComponent implements OnInit, OnDestroy {
    constructor(private readonly store$: Store<AppState>) {}

    interviewers: InterviewerModel[] = [];
    filter: CandidateFilterModel = new CandidateFilterModel();
    searchDate: TuiDay | null = null;;
    interviewer: InterviewerModel | undefined;
    userQuestionUpdate = new Subject<string>();
    displayStatues: CandidateStatusEnum[] = [ 
        CandidateStatusEnum.Applied, 
        CandidateStatusEnum.Interviewing, 
        CandidateStatusEnum.Offered, 
        CandidateStatusEnum.Hired 
    ];
    searchForm!: FormGroup;

    destroySubject$: Subject<boolean> = new Subject();

    ngOnInit(): void {
        this.searchForm = new FormGroup({
            formSearchName: new FormControl('', []),
            formSearchDate: new FormControl(this.searchDate, []),
            formSearchInterviewer: new FormControl(this.interviewer, [])
        });

        this.store$.select(SelectInterviewers).pipe(
            takeUntil(this.destroySubject$)
        ).subscribe(data => {
            if (data)
                this.interviewers = data;
        });

        this.searchForm.get('formSearchName')?.valueChanges.pipe(
            debounceTime(500),
            takeUntil(this.destroySubject$)
        ).subscribe(value => {
            this.filter = {...this.filter, SearchName: value };
            this.store$.dispatch(getCandidates({ payload: this.filter }));
        });

        this.searchForm.get('formSearchDate')?.valueChanges.pipe(
            takeUntil(this.destroySubject$)
        ).subscribe(value => {
            this.filter = {...this.filter, SearchDate: `${value.year}-${value.month + 1}-${value.day}` };
            this.store$.dispatch(getCandidates({ payload: this.filter }));
        });

        this.searchForm.get('formSearchInterviewer')?.valueChanges.pipe(
            takeUntil(this.destroySubject$)
        ).subscribe(value => {
            if (value)
                this.filter = {...this.filter, InterviewerId: value.id };
            else
                this.filter = {...this.filter, InterviewerId: '' };
            this.store$.dispatch(getCandidates({ payload: this.filter }));
        });
    }

    ngOnDestroy(): void {
        this.destroySubject$.next(true);
        this.destroySubject$.complete();
    }
}
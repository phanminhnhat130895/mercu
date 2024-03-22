import { Component, OnDestroy, OnInit } from "@angular/core";
import { tuiItemsHandlersProvider } from '@taiga-ui/kit';
import { InterviewerModel } from "../../models/input/interviewer.model";
import { CandidateFilterModel } from "../../models/output/get-candidate-filter.model";
import { TuiDay } from '@taiga-ui/cdk';
import { CandidateStatusEnum } from "../../common/enums/CandidateStatusEnum";
import { Subject } from 'rxjs';

@Component({
    selector: 'app-cadidate-list',
    templateUrl: './candidate-list.component.html',
    providers: [
        tuiItemsHandlersProvider({
            stringify: (item: InterviewerModel) => `${item.FirstName} ${item.LastName}`,
        }),
    ],
})
export class CandidateListComponent implements OnInit, OnDestroy {
    constructor() {}

    interviewers: InterviewerModel[] = [];
    filter: CandidateFilterModel = new CandidateFilterModel();
    searchName: string;
    searchDate: TuiDay | null = null;;
    interviewer: InterviewerModel;
    userQuestionUpdate = new Subject<string>();
    displayStatues: CandidateStatusEnum[] = [ 
        CandidateStatusEnum.Applied, 
        CandidateStatusEnum.Interviewing, 
        CandidateStatusEnum.Offered, 
        CandidateStatusEnum.Hired 
    ];

    ngOnDestroy(): void {
        throw new Error("Method not implemented.");
    }

    ngOnInit(): void {
        throw new Error("Method not implemented.");
    }

    filterCandidate(type: number) {
        switch (type) {
            case 0:
                this.filter.SearchName = this.searchName;
                break;
            case 1:
                if (this.searchDate)
                    this.filter.SearchDate = new Date(this.searchDate?.year, this.searchDate?.month, this.searchDate?.day, 0, 0, 0, 0);
                else
                    this.filter.SearchDate = null;
                break;
            case 2:
                this.filter.InterviewerId = this.interviewer.Id;
                break;
        }
    }
}
import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { CandidateStatusEnum } from "../../../../common/enums/CandidateStatusEnum";
import { CandidatesModel } from "../../../../models/input/candidates.model";
import { getCandidateStatusString } from "../../../../common/helper";

@Component({
    selector: 'app-candidate-column',
    templateUrl: './candidate-column.component.html'
})
export class CandidateColumnComponent implements OnInit, OnDestroy {
    constructor() {}

    @Input() status: CandidateStatusEnum;
    candidates: CandidatesModel[] = [];
    selectedCandidates: CandidatesModel[] = [];

    ngOnInit(): void {
        throw new Error("Method not implemented.");
    }

    ngOnDestroy(): void {
        throw new Error("Method not implemented.");
    }

    StatusName(status: CandidateStatusEnum) {
        return getCandidateStatusString(status);
    }

    onDropCandidate() {

    }
}
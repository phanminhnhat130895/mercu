import { Component, OnDestroy, OnInit } from "@angular/core";

@Component({
    selector: 'app-cadidate-list',
    templateUrl: './candidate-list.component.html',
})
export class CandidateListComponent implements OnInit, OnDestroy {
    ngOnDestroy(): void {
        throw new Error("Method not implemented.");
    }

    ngOnInit(): void {
        throw new Error("Method not implemented.");
    }
}
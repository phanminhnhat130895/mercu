import { Component, Input } from "@angular/core";
import { Router } from '@angular/router';
import { CandidatesModel } from "../../../../models/input/candidates.model";

@Component({
    selector: 'app-candidate-card',
    templateUrl: './candidate-card.component.html'
})
export class CandidateCardComponent {
    constructor(private router: Router) {}

    @Input() candidate: CandidatesModel;
    isChecked: boolean = false;

    goToCandidateDetail() {
        this.router.navigate([`/candidate-detail/${this.candidate.Id}`]);
    }

    onDragCandidate() {

    }

    onChecked() {
        
    }
}
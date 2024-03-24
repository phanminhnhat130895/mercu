export class UpdateCandidateRequest {
    public Candidate!: UpdateCandidateModel;
}

export class UpdateCandidateModel {
    public Id!: string;
    public FirstName!: string;
    public LastName!: string;
    public PhoneNumber!: string;
    public Email!: string;
}
import { CandidateStatusEnum } from "src/app/common/enums/CandidateStatusEnum";

export class UpdateCandidatesStatusRequest {
    public Data!: UpdateCandidatesStatus[];
}

export class UpdateCandidatesStatus {
    public id!: string;
    public status!: CandidateStatusEnum;
}
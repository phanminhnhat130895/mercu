import { CandidateStatusEnum } from "../../common/enums/CandidateStatusEnum";
import { BaseModel } from "../base.model";

export class CandidatesResponse {
    public candidates!: CandidatesModel[];
}

export class CandidatesModel extends BaseModel {
    public id!: string;
    public firstName!: string;
    public lastName!: string;
    public phoneNumber!: string;
    public email!: string;
    public status!: CandidateStatusEnum;
}
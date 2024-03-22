import { CandidateStatusEnum } from "../../common/enums/CandidateStatusEnum";
import { BaseModel } from "../base.model";

export class CandidatesModel extends BaseModel {
    public Id!: string;
    public FirstName!: string;
    public LastName!: string;
    public PhoneNumber!: string;
    public Email!: string;
    public Status: CandidateStatusEnum;
}
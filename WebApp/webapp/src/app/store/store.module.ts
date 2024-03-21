import { CommonModule } from "@angular/common";
import { InjectionToken, NgModule } from "@angular/core";
import { ActionReducer, ActionReducerMap, StoreModule } from "@ngrx/store";
import { StateNames } from "./names";
import { AppState } from "./state";
import { EffectsModule } from "@ngrx/effects";
import { StateEffects } from "./effects";
import { reducer } from './reducer';

export const FEATURE_REDUCER_TOKEN = new InjectionToken<ActionReducerMap<AppState>>(`${StateNames.NAME} Reducers`);

@NgModule({
    imports: [
        CommonModule,
        StoreModule.forFeature(StateNames.NAME, FEATURE_REDUCER_TOKEN),
        EffectsModule.forFeature([StateEffects]),
    ],
    declarations: [],
    providers: [
        StateEffects,
        {
            provide: FEATURE_REDUCER_TOKEN,
            useFactory: (): ActionReducer<AppState> => reducer,
        },
    ],
})
export class AppStoreModule {
}
import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { StoreModule } from "@ngrx/store";
import { EffectsModule } from "@ngrx/effects";
import { StateEffects } from "./effects";
import { metaReducers, reducers } from './reducer';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from "src/environments/environment";

@NgModule({
    imports: [
        CommonModule,
        StoreModule.forRoot(reducers, {
            metaReducers,
            runtimeChecks: {
              strictStateImmutability: true,
              strictActionImmutability: true,
            },
          }),
        EffectsModule.forRoot([StateEffects]),
        // Connects RouterModule with StoreModule, uses MinimalRouterStateSerializer by default
        StoreRouterConnectingModule.forRoot(),
        StoreDevtoolsModule.instrument({
            maxAge: 25, // Retains last 25 states
            logOnly: environment.production, // Restrict extension to log-only mode
        })
    ],
    declarations: [],
    providers: [],
})
export class AppStoreModule {
}
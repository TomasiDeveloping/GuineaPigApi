import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {HttpClientModule} from "@angular/common/http";
import {GuineaPigCardComponent} from './guinea-pig-card/guinea-pig-card.component';
import {HealthCheckComponent} from './modals/healt-check/health-check.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatDialogModule} from "@angular/material/dialog";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {PawsInfoBoxComponent} from './modals/paws-info-box/paws-info-box.component';
import {ChinInfoBoxComponent} from './modals/chin-info-box/chin-info-box.component';
import {EyesInfoBoxComponent} from './modals/eyes-info-box/eyes-info-box.component';
import {EarsInfoBoxComponent} from './modals/ears-info-box/ears-info-box.component';
import {FurInfoBoxComponent} from './modals/fur-info-box/fur-info-box.component';
import {DateAgoPipe} from './date-ago.pipe';
import {GuineaPigEditComponent} from './modals/guinea-pig-edit/guinea-pig-edit.component';
import {ToastrModule} from "ngx-toastr";
import {HealthChecksHistoryComponent} from './modals/healt-checks-history/health-checks-history.component';
import {HealthCheckDetailComponent} from './modals/healt-check-detail/health-check-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    GuineaPigCardComponent,
    HealthCheckComponent,
    PawsInfoBoxComponent,
    ChinInfoBoxComponent,
    EyesInfoBoxComponent,
    EarsInfoBoxComponent,
    FurInfoBoxComponent,
    DateAgoPipe,
    GuineaPigEditComponent,
    HealthChecksHistoryComponent,
    HealthCheckDetailComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    ReactiveFormsModule,
    FormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}

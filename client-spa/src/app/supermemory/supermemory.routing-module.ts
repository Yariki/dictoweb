import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AuthGuardService} from '../auth/auth-guard.service';
import {SupermemoryComponent} from './supermemory.component';
import {SmsettingsComponent} from './smsettings/smsettings.component';
import {SmrepeatingComponent} from './smrepeating/smrepeating.component';

const supermemoryRoutes: Routes = [
  { path: 'memory', component: SupermemoryComponent, canActivate: [AuthGuardService], children: [
      {path: '', component: SmsettingsComponent, canActivate: [AuthGuardService]},
      {path: 'settings', component: SmsettingsComponent, canActivate: [AuthGuardService]},
      {path: 'repeat', component: SmrepeatingComponent, canActivate: [AuthGuardService]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(supermemoryRoutes)],
  exports: [RouterModule]
})
export class SupermemoryRoutingModule {

}


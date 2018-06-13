import {NgModule} from '@angular/core';
import {PreloadAllModules, RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './core/home/home.component';
import {AuthGuardService} from './auth/auth-guard.service';
import {Level1Component} from './levels/level1/level1.component';
import {Level2Component} from './levels/level2/level2.component';

const appRoutes: Routes = [
  {path: '', component: HomeComponent, canActivate: [AuthGuardService]},
  {path: 'level1', component: Level1Component, canActivate: [AuthGuardService]},
  {path: 'level2', component: Level2Component, canActivate: [AuthGuardService]},

];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes,{ preloadingStrategy: PreloadAllModules})],
  exports: [RouterModule]
})
export class AppRoutingModule {

}

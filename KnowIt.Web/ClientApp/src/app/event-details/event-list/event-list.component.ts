import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { first } from 'rxjs/operators';
import { EventModel } from "../model/event";  
import { User } from 'src/app/models';
import { EventService } from '../event.service';
import { Observable } from 'rxjs';
import { Store, select } from '@ngrx/store';
import * as _Actions from '../state/actions/event.actions';
import * as fromState from '../state/reducers/event.reducers'; 
import * as fromSelectors from '../state/selectors/event.selectors';
import { MatDialog } from '@angular/material/dialog';
@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {

  public  _EventList = this.store.pipe(select(fromSelectors.selectAllEntities));
  
  isLoaded$: Observable<boolean>;
  loading: false;
  currentUser: User=null;
  constructor(
    private store: Store<fromState.State>,  
    private router: Router, ) { }
    entries: number = 10;
    selected: any[] = [];
    temp = [];
    activeRow: any;
  ngOnInit() {
    
    this.store.dispatch(_Actions.loadMultiple()); 
    //  if (!this.authenticationService.currentUserValue) {
    //       this.router.navigate(['/']);
    //   }
  //this.currentUser = this.authenticationService.currentUserValue.user; 

  
     
  }
  entriesChange($event) {
    this.entries = $event.target.value;
  }
  filterTable($event) {
    // let val = $event.target.value;
    // this.dataa = this.rows.filter(function(d) {
    //   for (var key in d) {
    //     if (d[key].toLowerCase().indexOf(val) !== -1) {
    //       return true;
    //     }
    //   }
    //   return false;
    // });
  }
  onActivate(event) {
    this.activeRow = event.row;
  }
  onSelect({ selected }) {
    this.selected.splice(0, this.selected.length);
    this.selected.push(...selected);
  }
  eventDeails(id){ 
    this.router.navigate(['event/editor',  id])
  
  }

}

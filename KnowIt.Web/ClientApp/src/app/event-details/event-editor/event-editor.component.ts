import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'; 
import {NgbDateStruct, NgbCalendar} from '@ng-bootstrap/ng-bootstrap'; 
import { EventModel as _model } from '../model/event';
 
import { Store, select } from '@ngrx/store'; 
import * as _Actions from '../state/actions/event.actions';
import * as fromState from '../state/reducers/event.reducers';
import * as fromSelectors from '../state/selectors/event.selectors';
 
@Component({
  selector: 'app-event-editor',
  templateUrl: './event-editor.component.html',
  styleUrls: ['./event-editor.component.css']
})
export class EventEditorComponent implements OnInit { 
  public eventForm: FormGroup = null;
  public _Event: _model= null;
  selectedCategory:number; 
  loading = false;
  currentUser=null;
  submitted = false;
  returnUrl: string;
  model: NgbDateStruct;
  date: {year: number, month: number};
  categoryData$: any; 
  constructor(  
    private store: Store<fromState.State>,  
    private calendar: NgbCalendar,
      private formBuilder: FormBuilder,
      private route: ActivatedRoute,
      private router: Router,   
  ) {
      // redirect to home if already logged in
      // if (this.eventService.currentUserValue) {
      //     this.router.navigate(['/']);
      // }
  }
  selectToday() {
    this.model = this.calendar.getToday();
  }
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.eventForm = this.formBuilder.group({
        id:[0],
        name: ['', Validators.required],
          description: ['', Validators.required],
          title: ['', Validators.required],  
      });
      let id = +params['id'];
      if (id != null && id>0) {
        this.route.params.subscribe(params => {

      this.store.dispatch(_Actions.loadSingle ({id:id.toString()}));
    }); 

      this.store.pipe(select(fromSelectors.getSingle)).subscribe((item)=>{
       
          if(item!=null){
          
this._Event=item;
            this.eventForm.patchValue({
              id: item.id,
              name: item.name,
              title: item.title,
              description: item.description, 
            })

          }
        },
        err => {
          console.log(err);
        },);
       
      }
    }, error => {
      console.log(JSON.stringify(error));
    });

     
      // get return url from route parameters or default to '/'
     // this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.eventForm.controls; }

  onSubmit() { 
      this.submitted = true; 
  if (this.eventForm.invalid) {
          return;
      }
      const _Event: _model = this.eventForm.value;
 
      this.returnUrl="event";
      this.loading = true;  
if(_Event.id>0){

  this.store.dispatch(_Actions._update({ _model:_Event}));
}else{

          this.store.dispatch(_Actions._create({ _model:_Event}));
}
     
this.router.navigate(['/events']);
  }

}

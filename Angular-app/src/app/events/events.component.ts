import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventService } from '../_services/Event.service';
import { Event } from '../_models/Event';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})

export class EventsComponent implements OnInit {
  
  imageWidth = 50;
  imageMargin = 2;
  imageOnOff = true;  

  filteredEvents: Event[];
  events: Event[];
  
  modalRef: BsModalRef;  
  registerForm: FormGroup;
  
  
  
  _filterList: string = '';  
 
  get filterList(): string{
    return this._filterList;
  }
  set filterList(value: string){
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterEvents(this.filterList) : this.events;
  }    

  constructor(
    private eventService: EventService,
    private modalService: BsModalService    
    ) {}

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
    this.validation();
    this.getEvents();
  }

  filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      event => event.name.toLocaleLowerCase().indexOf(filterBy) !== -1
      
    );
  }

  showImage(){
    this.imageOnOff = !this.imageOnOff;    
  }

  validation()  {
    this.registerForm = new FormGroup({
      type: new FormControl('',[Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
      name: new FormControl('',[Validators.required]),
      location: new FormControl('',[Validators.required ]),
      eventDate: new FormControl('',[Validators.required ]),
      imageURL: new FormControl('',[Validators.required ]),
      capacity: new FormControl('',[Validators.required, Validators.max(10000)]),
      phone: new FormControl('',[Validators.required ]),
      email: new FormControl('',[Validators.required, Validators.email])
    });
  }

  saveChanges()  {

  }


  getEvents(){
    this.eventService.getEventAll().subscribe(
      (_events: Event[]) => {
      this.events = _events;
      this.filteredEvents = this.events;      
      console.log(_events);
    }, error => {
      console.log(error);
    });
  }
}

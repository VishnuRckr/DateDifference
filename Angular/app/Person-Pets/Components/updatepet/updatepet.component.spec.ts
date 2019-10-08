import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatepetComponent } from './updatepet.component';

describe('AddpetComponent', () => {
  let component: UpdatepetComponent;
  let fixture: ComponentFixture<UpdatepetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdatepetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatepetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

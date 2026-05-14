import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DynamicFormModal } from './dynamic-form-modal';

describe('DynamicFormModal', () => {
  let component: DynamicFormModal;
  let fixture: ComponentFixture<DynamicFormModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DynamicFormModal],
    }).compileComponents();

    fixture = TestBed.createComponent(DynamicFormModal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

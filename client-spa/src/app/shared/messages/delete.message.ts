import { Component } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  template: `
    <div class="modal-header">
      <h4 class="modal-title">Hi there!</h4>
      <button type="button" class="close" aria-label="Close" (click)="activeModal.dismiss('close')">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">
      Are you sure that you want to delete word?
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-primary" (click)="activeModal.close('ok')">Delete</button>
      <button type="button" class="btn btn-danger" (click)="activeModal.dismiss('cancel')">Cancel</button>
    </div>
  `
})
export class DeleteMessage {

  constructor(private modalService: NgbModal, public activeModal: NgbActiveModal) {}
}

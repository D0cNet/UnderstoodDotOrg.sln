<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Article Entry Message Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Article_Entry_Message_Page" %>
 <!-- BEGIN PARTIAL: personalize-checklist -->
<div class="personalize-checklist-modal modal fade">
  <div class="personalize-checklist modal-dialog">
    <div class="modal-content">

      <div class="modal-header">
        <div class="checklist-close"><i class="icon-close"></i><span>Close</span></div>
        <div class="checklist-title">Personalize Your Experience</div>
      </div>

      <div class="modal-body">
        <div class="checklist-wrapper row">
          <div class="col col-14">
            <div class="checklist-question-wrapper">
              <div class="checklist-question">My child needs help with:</div>
              <div class="checkboxes-wrapper">
                <div class="checkbox-wrapper">
                  <label>
                    <input type="checkbox" name="q1a1">
                    <span>Reading</span>
                  </label>
                </div>
                <div class="checkbox-wrapper">
                  <label>
                    <input type="checkbox" name="q1a2">
                    <span>Math</span>
                  </label>
                </div>
                <div class="checkbox-wrapper">
                  <label>
                    <input type="checkbox" name="q1a3">
                    <span>Writing</span>
                  </label>
                </div>
                <div class="checkbox-wrapper">
                  <label>
                    <input type="checkbox" name="q1a4">
                    <span>Attention/hyperactivity/impulsivity</span>
                  </label>
                </div>
                <div class="checkbox-wrapper">
                  <label>
                    <input type="checkbox" name="q1a5">
                    <span>Organization, planning, time management</span>
                  </label>
                </div>
                <div class="checkbox-wrapper">
                  <label>
                    <input type="checkbox" name="q1a6">
                    <span>Spoken language</span>
                  </label>
                </div>
                <div class="checkbox-wrapper">
                  <label>
                    <input type="checkbox" name="q1a7">
                    <span>Listening comprehension</span>
                  </label>
                </div>
                <div class="checkbox-wrapper">
                  <label>
                    <input type="checkbox" name="q1a8">
                    <span>Social skills, including conversation</span>
                  </label>
                </div>
                <div class="checkbox-wrapper">
                  <label>
                    <input type="checkbox" name="q1a8">
                    <span>Motor skills</span>
                  </label>
                </div>
              </div>
            </div>
          </div>

          <div class="col col-10">
            <div class="checklist-question-wrapper">
              <div class="checklist-question">My Child is enrolled in:</div>
              <select name="question2">
                <option value="">Select Grade</option>
                <option>Grade 1</option>
                <option>Grade 2</option>
                <option>Grade 3</option>
                <option>Grade 4</option>
              </select>
            </div>
            <div class="checklist-question">My Child's Name:</div>
            <input type="text" name="question3" placeholder="Enter child's name" />
            <p class="checklist-question-description">
              Child's name is private - only viewable by you.
            </p>
          </div>
        </div><!-- .checklist-wrapper -->
      </div><!-- .modal-body -->

      <div class="modal-footer">
        <div class="checklist-actions">
          <input type="submit" value="Next">
        </div>
      </div>

    </div><!-- .modal-content -->
  </div><!-- .personalize-checklist -->
</div><!-- .personalize-checklist-modal -->

<!-- END PARTIAL: personalize-checklist -->
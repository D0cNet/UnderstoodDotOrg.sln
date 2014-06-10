<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsResultsPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsResultsPage" %>
<div class="container flush">
  <div class="row">
    <!-- article -->
    <div class="col col-16 behavior-advice-container">
      <!-- BEGIN PARTIAL: behavior-advice -->
<div class="behavior-advice-wrapper">
  <div class="behavior-advice">
    <div class="behavior-advice-title">Get Expert Advice</div>
    <div class="advice-question-wrapper">
      <label for="question1" class="visuallyhidden">Select Challenge</label>
      <select id="advice-challenge" name="question1">
        <option value="">Select Challenge</option>
        <option>Friendships</option>
        <option>Gives up easily</option>
        <option>Task-to-task transitions</option>
        <option>Overdependence</option>
        <option>Disorganization</option>
        <option>Initiating/finishing tasks/time management</option>
        <option>Anxiousness and fear</option>
        <option>Interpersonal problem solving (includes fairness and blame/responsibility) </option>
        <option>Social media/technology</option>
        <option>Frustration</option>
        <option>ADD</option>
        <option>Self-esteem</option>
        <option>Fitting in</option>
        <option>Peer interactions</option>
        <option>Interactions with adults</option>
        <option>Risk-taking</option>
        <option>Self-advocacy</option>
      </select>
    </div>

    <div class="advice-question-bottom clearfix">
      <div class="advice-question-wrapper select-container">
        <label for="question2" class="visuallyhidden">Select Challenge</label>
        <select id="advice-grade" name="question2">
          <option value="">Select Grade</option>
          <option>Toddler/Preschool</option>
          <option>Kindergarten</option>
          <option>Grade 1</option>
          <option>Grade 2</option>
          <option>Grade 3</option>
          <option>Grade 4</option>
          <option>Grade 5</option>
          <option>Grade 6</option>
          <option>Grade 7</option>
          <option>Grade 8</option>
          <option>Grade 9</option>
          <option>Grade 10</option>
          <option>Grade 11</option>
          <option>Grade 12</option>
          <option>After High School</option>
        </select>
      </div>

      <div class="behavior-advice-actions">
        <input class="submit-button" type="submit" value="Go">
      </div>
    </div>

    <a href="REPLACE" class="advice-more-link">Don't see your child's challenge?</a>
    <!-- BEGIN PARTIAL: suggest-a-behavior -->
<!-- Suggest a Behavior Modal -->
<div class="modal fade" id="suggest-a-behavior" tabindex="-1" role="dialog" aria-labelledby="suggest-a-behavior-modal" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body">
        <div class="suggest-a-behavior">
          <div class="alert-message hidden">We're sorry. We don't see your suggestion. Please type in the behavior issues that you would like us to include in the future.</div>
          <div class="checklist-close" data-dismiss="modal"><i class="icon-close"></i><span>Close</span></div>
          <h3>Suggest a challenge</h3>
          <p>Our experts want to know the issues that are important to youso we can continue to develop new strategies.</p>
          <textarea name="" placeholder="Enter your suggestion&hellip;"></textarea>
          <input type="submit" name="" class="submit-button" value="Send Suggestion">
        </div><!-- /.suggest a behavior -->
        <div class="suggest-a-behavior-confirmation" style="display:none;">
          <div class="checklist-close" data-dismiss="modal"><i class="icon-close"></i><span>Close</span></div>
          <h3>Thank you!</h3>
          <p>Parent feedback is very important to us! Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <input type="submit" name="" data-dismiss="modal" class="submit-button" value="Close Window">
          <div class="sign-up"><a href="REPLACE">Sign up with Understood.</a></div>
        </div><!-- /.suggest-a-behavior-confirmation -->
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<!-- END PARTIAL: suggest-a-behavior -->
  </div>
</div>

<!-- END PARTIAL: behavior-advice -->
    </div>

    <div class="col col-8 tool-related-articles-wrap behavior-tool-related-articles-large" style="height: 268px;">
      <!-- This is where behavior-tool-related-articles will move to in desktop (650px+) view-->
    <div class="behavior-tool-related-articles">
  <ul>
      <li><a href="REPLACE">10 Questions to ask about behavior issues</a></li>
      <li><a href="REPLACE">10 Questions to ask about behavior issues</a></li>
      <li><a href="REPLACE">10 Questions to ask about behavior issues</a></li>
  </ul>
  
</div></div>

  </div><!-- .row -->
</div><!-- .container -->

<div class="container behavior-results flush">
  <div class="row">
    <div class="col col-24">
      <!-- BEGIN PARTIAL: advice-results -->
<section class="advice-results">
  <div class="row">
    <div class="col col-24">
    <header>
      <h3>Work on task-to-task transitions</h3>
      <i class="icon-tooltip"></i>
      <a class="how-to-use" href="REPLACE">How to use these strategies</a>
    </header>
      </div>
  </div>
  <div class="results-outer-wrapper">
    <div class="results-wrapper">

      <div class="search-result">
        <div class="result-body">
          <div class="result-tip">Make a picture schedule</div>
          <div class="result-info">
            <span class="tip-comment">19</span>
            <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
          </div>
          <div class="result-hover">
            <div class="hover-link-wrapper">
              <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
            </div>
            <div class="hover-link-wrapper">
              <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
            </div>
          </div>
        </div>
        <a class="tip-view" href="REPLACE">View Tip</a>
      </div>

      <div class="search-result">
        <div class="result-body">
          <div class="result-tip">Start by demonstrating</div>
          <div class="result-info">
            <span class="tip-comment">19</span>
            <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
          </div>
          <div class="result-hover">
            <div class="hover-link-wrapper">
              <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
            </div>
            <div class="hover-link-wrapper">
              <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
            </div>
          </div>
        </div>
        <a class="tip-view" href="REPLACE">View Tip</a>
      </div>

      <div class="search-result">
        <div class="result-body">
          <div class="result-tip">Use color-coding</div>
          <div class="result-info">
            <span class="tip-comment">19</span>
            <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
          </div>
          <div class="result-hover">
            <div class="hover-link-wrapper">
              <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
            </div>
            <div class="hover-link-wrapper">
              <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
            </div>
          </div>
        </div>
        <a class="tip-view" href="REPLACE">View Tip</a>
      </div>

      <div class="search-result">
        <div class="result-body">
          <div class="result-tip">Create incentives for your child</div>
          <div class="result-info">
            <span class="tip-comment">19</span>
            <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
          </div>
          <div class="result-hover">
            <div class="hover-link-wrapper">
              <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
            </div>
            <div class="hover-link-wrapper">
              <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
            </div>
          </div>
        </div>
        <a class="tip-view" href="REPLACE">View Tip</a>
      </div>

      <div class="search-result">
        <div class="result-body">
          <div class="result-tip">Prepare your child for the day</div>
          <div class="result-info">
            <span class="tip-comment">19</span>
            <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
          </div>
          <div class="result-hover">
            <div class="hover-link-wrapper">
              <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
            </div>
            <div class="hover-link-wrapper">
              <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
            </div>
          </div>
        </div>
        <a class="tip-view" href="REPLACE">View Tip</a>
      </div>

      <div class="search-result">
        <div class="result-body">
          <div class="result-tip">Give fair warning</div>
          <div class="result-info">
            <span class="tip-comment">19</span>
            <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
          </div>
          <div class="result-hover">
            <div class="hover-link-wrapper">
              <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
            </div>
            <div class="hover-link-wrapper">
              <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
            </div>
          </div>
        </div>
        <a class="tip-view" href="REPLACE">View Tip</a>
      </div>

      <div class="search-result">
        <div class="result-body">
          <div class="result-tip">Give fair warning</div>
          <div class="result-info">
            <span class="tip-comment">19</span>
            <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
          </div>
          <div class="result-hover">
            <div class="hover-link-wrapper">
              <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
            </div>
            <div class="hover-link-wrapper">
              <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
            </div>
          </div>
        </div>
        <a class="tip-view" href="REPLACE">View Tip</a>
      </div>

      <div class="search-result">
        <div class="result-body">
          <div class="result-tip">Give fair warning</div>
          <div class="result-info">
            <span class="tip-comment">19</span>
            <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
          </div>
          <div class="result-hover">
            <div class="hover-link-wrapper">
              <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
            </div>
            <div class="hover-link-wrapper">
              <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
            </div>
          </div>
        </div>
        <a class="tip-view" href="REPLACE">View Tip</a>
      </div>

      <div class="search-result">
        <div class="result-body">
          <div class="result-tip">Give fair warning</div>
          <div class="result-info">
            <span class="tip-comment">19</span>
            <span class="tip-like" href="REPLACE"><i class="icon-advice-like"></i>3</span>
          </div>
          <div class="result-hover">
            <div class="hover-link-wrapper">
              <a class="tip-save" href="REPLACE"><i class="icon-advice-save"></i>Save This</a>
            </div>
            <div class="hover-link-wrapper">
              <a class="tip-print" href="REPLACE"><i class="icon-advice-print"></i>Print This</a>
            </div>
          </div>
        </div>
        <a class="tip-view" href="REPLACE">View Tip</a>
      </div>

    </div><!-- .results-wrapper -->
  </div><!-- .results-outer-wrapper -->

  <a class="results-more-link" href="REPLACE"><span>More Results</span><i class="icon-results-more"></i></a>
</section>

<!-- END PARTIAL: advice-results -->
    </div>
  </div>
</div><!-- .container -->
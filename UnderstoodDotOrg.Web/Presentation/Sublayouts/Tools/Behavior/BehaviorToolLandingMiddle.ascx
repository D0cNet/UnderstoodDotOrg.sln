<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolLandingMiddle.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.Behavior.BehaviorToolLandingMiddle" %>

      <!-- Hero Image -->
<div class="container flush hero-container-wrap">
  <!-- BEGIN PARTIAL: hero-image -->
<section class="hero-image-container">
  <img alt="1200x475 Placeholder" src="http://placehold.it/1200x475" />
  <div class="hero-text-container">
    <div class="row">
      <div class="col col-24">
        <div class="hero-text">
          <header>
            <h1>Your Expert Advisor</h1>
          </header>
          <p>Practical advice on everyday challenges from our experts</p>
          <a href="REPLACE">Meet the experts</a>
        </div>
      </div>
    </div>
  </div>
</section>
<!-- END PARTIAL: hero-image -->
</div>
<!-- end Hero Image -->
<!-- Get Expert Advice -->
<div class="container flush behavior-advice-container-wrapper">
  <div class="row">
    <div class="col col-16 centered behavior-advice-container behavior-advice-container-pull">
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
  </div>
</div>
<!-- end Get Expert Advice -->

<!-- What Parents are Saying -->
<!-- BEGIN PARTIAL: comment-gallery -->
<div class="container comment-gallery">
  <div class="row">
    <div class="col col-24">
      <h2>What parents are saying...</h2>
    </div>
  </div>
  <div class="row">
    <div class="col slider-col col-18 offset-4">
      <div class="comment-gallery-container">
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi Adipisc est un...<a href="REPLACE">read more</a></p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">13rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">23rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">33rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">43rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">53rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
        </li>
        <li>
          <p>Lorem ipsum dolor sit amet cum diceam partur est un ligula eget. Turing adipiscing ma cuming diceam parturi.</p>
          <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
          <h4>Parent</h4>
          <a href="REPLACE">3rd grader & Task-to-Task Transitions</a>
        </li>
      </div>
    </div>
  </div>
</div>
<!-- END PARTIAL: comment-gallery --><!-- end What Parents are Saying -->
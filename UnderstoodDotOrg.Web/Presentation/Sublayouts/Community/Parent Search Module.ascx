<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Search Module.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Search_Module" %>
<div class="options-search">
                    <div class="container-parents-search-zip">
                        <label for="parents-search-zip" class="label-text">Enter Zip Code:</label>
                        <input name="parents-search-zip" id="parents-search-zip" placeholder="Zip Code" type="text" aria-required="true" />
                    </div>
                    <div class="container-parents-search-distance">
                        <label for="parents-search-distance" class="label-slider">Miles within zip code:</label>
                        <div id="parents-search-distance-slider"></div>
                        <input type="hidden" name="parents-search-distance" id="parents-search-distance" data-start-low="0" data-start-high="20"
                        data-values="0,5,10,15,20,25,30,35,40,45,50" data-labels="0,5,10,15,20,25,30,35,40,45,50+" />
                    </div>
                    <div class="container-parents-search-grade">
                        <label class="label-slider" for="parents-search-grade">Grade range:</label>
                        <div id="parents-search-grade-slider"></div>
                        <input type="hidden" name="parents-search-grade" id="parents-search-grade" data-collision="2" data-start-low="prek" data-start-high="8" data-values="prek,1,2,3,4,5,6,7,8,9,10,11,12,adult" data-labels="Pre-K,Grade 1,Grade 2,Grade 3,Grade 4,Grade 5,Grade 6,Grade 7,Grade 8,Grade 9,Grade 10,Grade 11,Grade 12,Adult"/>
                    </div>
                    <select name="parents-search-issue" id="parents-search-issue" aria-required="true">
                        <option value="">Child's Issue</option>
                        <option>Grade 1</option>
                        <option>Grade 2</option>
                        <option>Grade 3</option>
                        <option>Grade 4</option>
                    </select>
                    <select name="parents-search-topic" id="parents-search-topic" aria-required="true">
                        <option value="">Topic</option>
                        <option>Grade 1</option>
                        <option>Grade 2</option>
                        <option>Grade 3</option>
                        <option>Grade 4</option>
                    </select>
                    <div class="checkboxes">
                        <div class="checkbox">
                            <input type="checkbox" name="search-include-members" id="search-include-members" checked="checked" />
                            <label for="search-include-members" class="label-checkbox">Members</label>
                        </div>
                        <div class="checkbox">
                            <input type="checkbox" name="search-include-moderators" id="search-include-moderators" checked="checked" />
                            <label for="search-include-moderators" class="label-checkbox">Moderators</label>
                        </div>
                        <div class="checkbox">
                            <input type="checkbox" name="search-include-experts" id="search-include-experts" checked="checked" />
                            <label for="search-include-experts" class="label-checkbox">Experts</label>
                        </div>
                    </div>
                    <button class="button">Search</button>
                </div>
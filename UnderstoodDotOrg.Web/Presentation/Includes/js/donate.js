﻿$(document).ready(function () {
    function ConvioDonation() {
        //Constants
        this.requestBaseUrl = "https://secure2.convio.net/ncld/site/CRDonationAPI"
        this.method = "donate";
        this.apiKey = "XXXXXX";
        this.apiVersion = "1.0";
        this.responseFormat = "json";

        //Convio Form
        this.convioFormId = "XXXXXX";
        this.convioDonationLevelId = "XXXXXX";

        //Gift Amount
        this.amount = "";

        //Gift for Someone
        this.sendEcard = false;
        this.ecardInfo = {
            "name": "",
            "email": "",
            "message": ""
        };

        //Recurring Gift
        this.recurMonthly = false;

        //Payment 
        this.billingAddress = {
            "name": {
                "first": "",
                "last": ""
            },
            "street": {
                "street1": "",
                "street2": ""
            },
            "city": "",
            "state": "",
            "zip": ""
        };
        this.donorInfo = {
            "email": "",
            "phone": {
                "number": "",
                "type": "" //one of: home, work, other
            }
        };
        this.payWithCredit = true;
        this.cardInfo = {
            "number": "",
            "exp_month": "",
            "exp_year": "",
            "cvv": ""
        };
        this.checkInfo = {
            "account_number": "",
            "routing_number": ""
        };

        this.getRequestUrl = function () {
            var qs =
				//Constants
				"?method=" + this.method +
				"&api_key=" + this.apiKey +
				"&v=" + this.apiVersion +
				"&response_format=" + this.responseFormat +
				//Convio Form
				"&form_id=" + this.convioFormId +
				"&level_id=" + this.convioDonationLevelId +
				//Gift Amount
				"&other_amount=" + this.amount +
				//Recurring Gift
				"&level_autorepeat=" + this.recurMonthly +
				//Payment 
				"&billing.name.first=" + this.billingAddress.name.first +
				"&billing.name.last=" + this.billingAddress.name.last +
				"&billing.address.street1=" + this.billingAddress.street1 +
				"&billing.address.street2=" + this.billingAddress.street2 +
				"&billing.address.city=" + this.billingAddress.city +
				"&billing.address.state=" + this.billingAddress.state +
				"&billing.address.zip=" + this.billingAddress.zip +
				"&donor.email=" + this.donorInfo.email +
				"&donor.phone=" + this.donorInfo.phone.number +
				"&donor.phone_type=" + this.donorInfo.phone.type;

            if (this.payWithCredit) {
                qs +=
					"&card_number=" + this.cardInfo.number +
					"&card_exp_date_month=" + this.cardInfo.exp_month +
					"&card_exp_date_year=" + this.cardInfo.exp_year +
					"&card_cvv=" + this.cardInfo.cvv;
            } else {
                qs +=
					"&ach_account=" + this.checkInfo.account_number +
					"&ach_routing=" + this.checkInfo.routing_number;
            }

            //Gift for Someone - TODO
            if (this.sendEcard) {
                //qs += "&ecard.send=true&"
            }

            var url = this.requestBaseUrl + qs;
            console.log(url);
            return url;
        };
    };

    var donation = new ConvioDonation();

    var $donateWrapper = $(".donate-choose-gift");

    //Gift Amount
    var $btnDonateAmount = $donateWrapper.find("div.choose-gift-wrapper button.donate-amount-button");
    var $tbDonateAmount = $("#donate-amount");

    $btnDonateAmount.on("click", function () {
        var value = $(this).attr("data-param-value");
        $tbDonateAmount.val(value);
    });

    //Gift for Someone
    var $btnDonateEcard = $donateWrapper.find("div.gift-for-section button.ecard-button");

    $btnDonateEcard.on("click", function () {
        donation.sendEcard = $(this).hasClass(".send-ecard-false");
    });

    //Recurring Gift
    $("#gift-occurrence-once").on("click", function () {
        donation.recurMonthly = false;
    });

    $("#gift-occurrence-monthly").on("click", function () {
        donation.recurMonthly = true;
    });

    //Payment 
    $("#pay-option-credit").on("click", function () {
        donation.payWithCredit = true;
    });

    $("#pay-option-check").on("click", function () {
        donation.payWithCredit = false;
    });

    //Submit
    var $btnSubmitDonation = $("#submit-donation");

    $btnSubmitDonation.on("click", function () {
        //Gift Amount
        donation.amount = $tbDonateAmount.val();

        //Gift for Someone
        if (donation.sendEcard) {
            donation.ecardInfo.name = $("#donate-ecard-name").val();
            donation.ecardInfo.email = $("#donate-ecard-email").val();
            donation.ecardInfo.message = $("#donate-ecard-Message").val();
        }

        //Payment
        donation.billingAddress.name.first = $("#donate-first-name").val();
        donation.billingAddress.name.last = $("#donate-last-name").val();
        donation.billingAddress.street.street1 = $("#donate-address1").val();
        donation.billingAddress.street.street2 = $("#donate-address2").val();
        donation.billingAddress.city = $("#donate-city").val();
        donation.billingAddress.state = $("#state-dropdown").val();
        donation.billingAddress.zip = $("#donate-zip").val();

        donation.donorInfo.email = $("#donate-email").val();
        donation.donorInfo.phone.number = $("#donate-phone").val();
        donation.donorInfo.phone.type = $("#phone-type").val();
        donation.donorInfo.phone.type = donation.donorInfo.phone.type ? donation.donorInfo.phone.type : "other";

        if (donation.payWithCredit) {
            donation.cardInfo.number = $("#card-number-input").val();
            donation.cardInfo.exp_month = $("#month-dropdown").val();
            donation.cardInfo.exp_year = $("#year-dropdown").val();
            donation.cardInfo.cvv = $("#ccv-input").val();
        } else {
            donation.checkInfo.account_number = $("#donate-account-number").val();
            donation.checkInfo.routing_number = $("#donate-account-routing").val();
        }

        var requestUrl = donation.getRequestUrl();
    });
});
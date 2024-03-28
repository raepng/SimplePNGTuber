var modelLoaded = false;
var speaking = false;
var blinking = false;
var blink = 0;

function getNewModel(modelName) {
    modelLoaded = false;
    $.get("http://127.0.0.1:8000/getmodel/" + modelName, function (data) {
        console.log(data);
        var model = $("#model");
        model.children().remove();
        for (const [key, value] of Object.entries(data.expressions)) {
            var expression = $('<div class="expression" id="exp_' + key + '"></div>');
            for (var i = 0; i < 4; i++) {
                var img = $('<img class="exp exp' + i + '" src="data:image/png;base64, ' + value[i] + '">');
                img.css("position", "absolute");
                if (i > 0) {
                    img.css("visibility", "hidden");
                }
                expression.append(img);
            }
            expression.css("position", "absolute");
            if (key !== "neutral") {
                expression.css("visibility", "hidden");
            }
            model.append(expression);
        }
        for (const [key, value] of Object.entries(data.accessories)) {
            var accessory = $('<img class="accessory" id="acc_' + key + '" src="data:image/png;base64, ' + value + '">');
            accessory.css("z-index", data.settings.AccessoryLayers[key]);
            accessory.css("position", "absolute");
            accessory.css("visibility", "hidden");
            model.append(accessory);
        }
        modelLoaded = true;
    });
}

function updateState() {
    $('.exp').css("visibility", "hidden");
    if (speaking) {
        if (blinking) {
            $('.exp3').css("visibility", "visible");
        } else {
            $('.exp1').css("visibility", "visible");
        }
    } else {
        if (blinking) {
            $('.exp2').css("visibility", "visible");
        } else {
            $('.exp0').css("visibility", "visible");
        }
    }
}

var webSocket = $.simpleWebSocket({ url: 'ws://127.0.0.1:8001/model', dataType: 'text' });
webSocket.listen(function (data) {
    console.log(data);

    if (data.startsWith("model: ")) {
        var modelName = data.substring(7);
        getNewModel(modelName);
    } else if (data.startsWith("expression: ")) {
        var expName = data.substring(12);
        $('.expression').css("visibility", "hidden");
        $('#exp_' + expName).css("visibility", "visible");
    } else if (data.startsWith("speaking: ")) {
        speaking = data.substring(10) === "True";
        updateState();
    } else if (data.startsWith("accessory: ")) {
        var accActive = data.substring(11).split(" ");
        if (accActive[1] === "True") {
            $('#acc_' + accActive[0]).css("visibility", "visible");
        } else {
            $('#acc_' + accActive[0]).css("visibility", "hidden");
        }
    }
});
webSocket.send('ping').done(function () {
    console.log("ping sent");
});
setInterval(function () {
    if (!modelLoaded) {
        return;
    }
    if (blink == 0) {
        blinking = false;
        updateState();
    }
    if (Math.random() < 0.5) {
        blink += 0.03;
    }
    if (blink > 1) {
        blink = 0;
        blinking = true;
        updateState();
    }
}, 100);
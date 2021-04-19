//gateway link that grabs all comics with the hashed md5 code at the end md5(ts + private + public) -> md5 generator to convert
//https://gateway.marvel.com/v1/public/comics?ts=1&apikey=7fe78693ca11a28d23d65b1e45722a27&hash=66062f1219c21aafc3eda7d3b6ca78ee


var marvel = {
    render: function () {
        var url = "https://gateway.marvel.com/v1/public/comics?ts=1&apikey=7fe78693ca11a28d23d65b1e45722a27&hash=66062f1219c21aafc3eda7d3b6ca78ee";
        var message = document.getElementById("message");
        var footer = document.getElementById("footer");
        var marvelContainer = document.getElementById("marvel-container");

        $.ajax({
            url: url,
            type: "GET",
            beforeSend: function () {
                message.innerHTML = "Loading...";
            },
            complete: function () {
                message.innerHTML = "Successfully loaded!";
            },
            success: function (data) {
                footer.innerHTML = data.attributionHTML;
                var string = "";
                string += "<div class='row'>";

                for (var i = 0; i < data.data.results.length; i++) {
                    var element = data.data.results[i];
                    console.log(element.title);

                    string += "<div class='col-md-3'>";
                    string += " <a href='" + element.urls[0].url + "' target='_blank'>"
                    string += "     <img src='" + element.thumbnail.path + "/portrait_fantastic." + element.thumbnail.extension + "' />";
                    string += " </a>";
                    string += " <h4>" + element.title + "</h4>";
                    string += "</div>";

                    if ((i + 1) % 4 == 0) {
                        string += "</div>";
                        string += "<div class='row'>";
                    }
                }
                marvelContainer.innerHTML = string;

            },
            error: function () {
                message.innerHTML = "Oops, seems like nothing is here :(";
            }
        });
    }
};
marvel.render();
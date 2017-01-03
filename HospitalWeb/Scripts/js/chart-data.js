var pieData = [];

$.getJSON("CountDeathLastSevenDays", function (data) {
    //var array = [];
    //for (var x = 0; x < data.length; x++) {
    //    array.push(data[x].length);
       
    //}
    var dataaaa = [];
    for (var x = 0; x < data.length; x++) {
        dataaaa.push({
            value:data[x].length,
            color: '#'+(Math.random() * 0xFFFFFF << 0).toString(16),
            highlight: '#'+(Math.random() * 0xFFFFFF << 0).toString(16),
            label: parseJsonDate(data[x][0].DateOfDeath)
        })
    }

    pieData = 
       
				dataaaa
				

    

});

var doughnutData = [];
$.getJSON("CountBirthLastSevenDays", function (data) {
    //var array = [];
    //for (var x = 0; x < data.length; x++) {
    //    array.push(data[x].length);

    //}
    var dataa = [];
    for (var x = 0; x < data.length; x++) {
        dataa.push({
            value: data[x].length,
            color: '#' + (Math.random() * 0xFFFFFF << 0).toString(16),
            highlight: '#' + (Math.random() * 0xFFFFFF << 0).toString(16),
            label: parseJsonDate(data[x][0].DateOfBirth)
        })
    }
    console.log(dataa);
    doughnutData =

				dataa



    console.log(data);
});

var bar = [];

$.getJSON("CountAppointment", function (data) {
    var array = [];
    for (var x = 0; x < data.length; x++) {
        array.push(data[x].length);

    }
    var dataaaa = [];

    for (var x = 0; x < data.length; x++) {
        dataaaa.push({
            value: data[x].length,
            color: '#' + (Math.random() * 0xFFFFFF << 0).toString(16),
            highlight: '#' + (Math.random() * 0xFFFFFF << 0).toString(16),
            label: parseJsonDate(data[x][0].DateOfDeath)
        })
    }

    bar = dataaa;

});





function parseJsonDate(jsonDateString) {
    return new Date(parseInt(jsonDateString.replace('/Date(', ''))).toDateString();
}
var randomScalingFactor = function () { return Math.round(Math.random() * 20) };
	
var barChartData = {
    labels: ["January", "February", "March", "April", "May", "June", "July"],
    datasets: [
        {
            fillColor: "rgba(220,220,220,0.5)",
            strokeColor: "rgba(220,220,220,0.8)",
            highlightFill: "rgba(220,220,220,0.75)",
            highlightStroke: "rgba(220,220,220,1)",
            data: [bar, bar, randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
        },
        {
            fillColor: "rgba(48, 164, 255, 0.2)",
            strokeColor: "rgba(48, 164, 255, 0.8)",
            highlightFill: "rgba(48, 164, 255, 0.75)",
            highlightStroke: "rgba(48, 164, 255, 1)",
            data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
        }
    ]

}


	
			
	
window.onload = function(){


	var chart3 = document.getElementById("doughnut-chart").getContext("2d");
	window.myDoughnut = new Chart(chart3).Doughnut(doughnutData, {responsive : true
	});
	var chart4 = document.getElementById("pie-chart").getContext("2d");
	window.myPie = new Chart(chart4).Pie(pieData, {responsive : true
	});

	var chart6 = document.getElementById("bar-chart").getContext("2d");
	window.myBar = new Chart(chart6).Bar(barChartData, {
		responsive : true
	});
};
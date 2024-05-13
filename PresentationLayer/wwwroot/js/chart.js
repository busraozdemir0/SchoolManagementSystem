$(document).ready(function () {
    $.ajax({
        url: '/Student/LessonVideoStatistics/LessonVideoChart',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var watchedCount = data.watchedCount;
            var totalVideos = data.totalVideos;

            // Chart.js ile grafik olusturma islemleri
            var ctx = document.getElementById('myChart').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: ['İzlenen Videolar', 'Toplam Videolar'],
                    datasets: [{
                        label: 'Video İzleme Durumu',
                        data: [watchedCount, totalVideos],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }
    });
});


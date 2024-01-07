var countOfAnswerd = document.getElementById('Countanswer')
var countOfNotAnswerd = document.getElementById('CountnotAnswer')
//emloyeeId
var employeeId = getEmployeeId();
// questions count
var sz = document.getElementsByClassName("qNum").length;
var clock = document.getElementById('timer');

// timer function
window.onload = function () {
    var tenMinutes = 60 * 10;
    Settimer(tenMinutes);
};

function Settimer(duration) {
    var timer = duration, minutes, seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        clock.textContent = minutes + ":" + seconds;

        if (--timer < 0) {
            Swal.fire({
                title: "Exam is Ended",
                showConfirmButton: false,
                timer: 1500
            });
            window.location.href = '/Exam/EmployeeEndExam';
        }
    }, 1000);
}

//remove checked
function removeChecked() {
    $('input[name="answer"]').prop('checked', false);
}


// when click on question
$(document).ready(function () {
    $('.Question').on('click', function () {
        var questionId = $(this).data('id');
        removeChecked();
        displayQuestion(questionId);
        getEmployeeChoice(employeeId, questionId);
    });
});

$('#CountnotAnswer').text(sz);

//get count of questions answerd
function getCountOfAnswerdQuestion(employeeId) {
    $.ajax({
        url: '/Api/AdminApi/GetCountAnswerdQuestion/?EmployeeId=' + employeeId,
        method: 'GET',
        success: function (response) {
            $('#Countanswer').text(response);
            $('#CountnotAnswer').text(sz-response);
        },
        error: function () {
            console.log("error when display question");
        }
    });
}


// add active background when click on question
function AddACtiveClass(numClass) {
    for (var i = 0; i < sz; i++)
        document.getElementsByClassName("qNum")[i].classList.remove("active");
    var q = document.getElementsByClassName("qNum")[numClass];
    if (!q.classList.contains("text-bg-success"))
        q.classList.add("active");
}

//get next question
function nextQuestion() {
    var currentQuestionNumber;
    for (var i = 0; i < sz; i++) {
        if (document.getElementsByClassName("qNum")[i].classList.contains("active")) {
            currentQuestionNumber = i + 1;
            break;
        }
    }
    if (currentQuestionNumber >= sz)
        AddACtiveClass(0);
    else
        AddACtiveClass(currentQuestionNumber);
    removeChecked();
    displayQuestion(getQuestionId());
    getEmployeeChoice(employeeId, getQuestionId());
}


// exit exam

function LogOut() {
    Swal.fire({
        title: "Are you sure?",
        text: "You are Leave Exam!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, Exit"
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = '/Exam/EmployeeEndExam';
        }
    });
}


// when click on save and next btn
function CheckUserCheckedAnswer() {
    $(document).ready(function () {
        if ($("input[name='answer']:checked").val()) {
            var employeeAnswer = $("input[name='answer']:checked").val();
            var questionId = getQuestionId();
            SaveAnswer(employeeId, questionId, employeeAnswer);
            nextQuestion();
        }
        else {
            alert('No Answer To Save');
        }
    });
}
// save employee answer
function SaveAnswer(empId, QuestionId, EmpAnswer) {
    var data = {
        EmployeeId: empId,
        EmployeeChoice: EmpAnswer,
        QuestionId: QuestionId
    };
    $.ajax({
        method: "POST",
        url: "/Api/AdminApi/AddAnswer",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (response) {
            getCountOfAnswerdQuestion(getEmployeeId());
            $(`#${QuestionId} a`).addClass('text-bg-success');
        },
        error: function (error) {
            getCountOfAnswerdQuestion(getEmployeeId());
            $(`#${QuestionId} a`).addClass('text-bg-success');           
        }
    });
}

function getEmployeeChoice(EmpId,QuestionId) {
    var data = {
        EmployeeId: EmpId,
        QuestionId: QuestionId,
               };
    $.ajax({
        method: "POST",
        data: JSON.stringify(data),
        url: "/Api/AdminApi/GetQuestionStates",
        contentType: 'application/json',
        success: function (response) {
            $("input[name='answer'][value='" + response + "']").prop("checked", true);
        },
        error: function () {
            console.log("error when get question state");
        }
    });
}
// display first qustion
displayQuestion(getQuestionId())

//get question id;
function getQuestionId() {
    for (var i = 0; i < sz; i++) {
        if (document.getElementsByClassName("qNum")[i].classList.contains("active")) {
            return document.getElementsByClassName("qNum")[i].getAttribute('id');
        }
    }
}

//display question 
function displayQuestion(id) {
    $.ajax({
        url: '/Api/AdminApi/GetQuestion/?questionId=' + id,
        method: 'GET',
        success: function (response) {
            $('#contain-answer').removeClass('d-none')
            var questionObject = JSON.parse(response);
            $('#question-text').text(questionObject.Text);
            $('#question-choiceA').text(questionObject.choiceA);
            $('#question-choiceB').text(questionObject.choiceB);
            $('#question-choiceC').text(questionObject.choiceC);
        },
        error: function () {
            console.log("error when display question");
        }
    });
}


//prevent refresh
function disableF5(e) { if ((e.which || e.keyCode) == 116 || (e.which || e.keyCode) == 82) e.preventDefault(); };
$(document).ready(function () {
    $(document).on("keydown", disableF5);
});
var a = 0;
var currentUser;
var islogged=false;
function signup() {
        if (a == 0) {
        document.querySelector(".login-form").style.display = 'none';
        document.querySelector(".signup-form").style.display = 'block';
        document.querySelector(".nav button").innerHTML = 'Log In';
        a = a + 1
    }
    else if (a == 1) {
        document.querySelector(".login-form").style.display = 'block';
        document.querySelector(".signup-form").style.display = 'none';
        document.querySelector(".nav button").innerHTML = 'SignUp';
        a = 0;
    }

    else if(a==2){
        location.reload(true);
    }

}

function getallposts(){
    $('.blogs').empty();
    $.ajax({
        url: "http://localhost:49215/getpostswithcomments",
        method: "GET",
        dataType: "JSON",
        success: (blog) => {
            post = blog;
            Displayblog();
        },
        error: () => alert('Error occurred')
    });
}


function Displayblog() {
    for (let i = 0; i < post.length; i++) {
        $(".blogs").prepend(makepost(post[i]));
    }
}


function makepost(blog) {
    return `<div class="post">
    <h1>${blog.Title}</h1>
    <h3>User Name:${blog.UserName}</h3> 
    <h2>Category: ${blog.Category}</h2>
    <p id='content'>${blog.Content}</p>
    <p>Comments: ${blog.Comments}</p>
    <button class="delete-button" onClick="deletePost(${blog.PostID},${blog.UserID})">Delete</button>
    <button class="edit-button" onClick="showEditForm(${blog.PostID},${blog.UserID})" href="#editForm">Edit</button>
</div>`;
}




var AllUsers;
$.ajax({
    url: "http://localhost:49215/GetUsers",
    method: "GET",
    dataType: "JSON",
    success: (response) => {
        AllUsers = response;
    },
    error: () => {
        alert("Error: Can not Get Users Information");
    }
});

$(".login-btn").click((event) => {
    event.preventDefault();
    var b = 0;
    UserEmail = $(".login-form input[name='email']").val();
    Password = $(".login-form input[name='password']").val();
    for (let i = 0; i < AllUsers.length; i++) {
        if (UserEmail === AllUsers[i].Email && Password == AllUsers[i].Password) {
            document.querySelector(".login-form").style.display = 'none';
            document.querySelector(".signup-form").style.display = 'none';
            document.querySelector(".after-login").style.display = 'block';
            document.querySelector('.nav input').style.display='block';
            document.querySelector(".nav button").innerHTML = 'Log Out';
            currentUser = AllUsers[i];
            b = 1; a=2;
        }
    }
    if (b == 0) {
        alert("Invalid User Name or PassWord!");
    };
});

$(".signup-btn").click((event) => {
    event.preventDefault();
    const signupdata = {
        Email: $(".signup-form input[name='email']").val(),
        UserName: $(".signup-form input[name='username']").val(),
        Password: $(".signup-form input[name='password']").val(),
    };
    var emailexists = false;
    for (let i = 0; i < AllUsers.length; i++) {
        if ($(".signup-form input[name='email']").val() == AllUsers[i].Email) {
            alert('Email already associated with another account!');
            emailexists = true;
            break;
        }
    }
    if (!emailexists) {
        if (signupdata.Email != "" && signupdata.UserName != "" && signupdata.Password != "") {
            $.ajax({
                url: "http://localhost:49215/AddUser",
                method: "POST",
                data: signupdata,
                success: () => {
                    alert("Account Created successfully!");
                    alert("LogIn to your New Account");
                    location.reload(true);
                },
                error: () => {
                    alert("Can't Create Account");
                }
            });
        }
        else {
            alert('Fill all required fields!');
        }
    }
})


$(".nav input").click((event)=>{
event.preventDefault();
let pswrd=prompt('Enter you Password:');
if(pswrd==currentUser.Password){
    Deleteuserfunction();
}
else{
    alert('Incorrect Password');
}

});

function Deleteuserfunction(){
$.ajax({
url:'http://localhost:49215/deleteuser?id='+currentUser.UserID,
method:'DELETE',
success:()=>{
    alert('Account deleted successfully!');
    location.reload(true);
},

error:()=>{
    alert('error occured while deleting account. Try Later');
}
});
}

getCategories();
function deletePost(postId, uzrid) {
    if (uzrid == currentUser.UserID) {
        if (confirm("Are you sure you want to delete this post?")) {
            const deleteUrl = "http://localhost:49215/DeletePost?id=" + postId;

            $.ajax({
                url: deleteUrl,
                method: "DELETE",
                success: (response) => {
                    alert("Post deleted successfully!");
                    getallposts();

                },
                error: () => {
                    alert("Error occurred while deleting the post.");
                }
            });
        }
    }
    else {
        alert("you don't have permission to delete this post!");
    }
}

function showEditForm(postid, uzrid) {
    if (uzrid == currentUser.UserID) {
        $("#editForm input[name='postId']").val(postid); // Use .val() to set the value
        $("#editForm").show(); // Show the edit form
    }

    else if (uzrid != currentUser.UserID) {
        alert("You are not authorized for this");
    }
}

$("#editForm button").click((event) => {
    event.preventDefault();

    var updateData = {
        postid: $("#editForm input[name='postId']").val(), // Get postId from input field
        title: $("#editForm input[name='title']").val(),
        content: $("#editForm textarea[name='content']").val(),
    };

    if (updateData.postid != null && updateData.title != "" && updateData.content != "") {
        $.ajax({
            url: "http://localhost:49215/UpdatePost",
            method: "PUT",
            data: updateData,
            success: (response) => {
                alert("Post updated successfully!");
                document.querySelector('#editForm').style.display='none';
                getallposts();
            },
            error: () => {
                alert("Error occurred while updating the post.");
            }
        });
    } else {
        alert("Fill all details!");
    }
});

$("#newcatForm").submit((event) => {
    event.preventDefault();
    const CatData = { CategoryName: $("#newcatForm Input[type='text']").val() };
    $.ajax({

        url: "http://localhost:49215/addcategory",
        method: "POST",
        data: JSON.stringify(CatData),
        contentType: "application/json",
        success: (response) => {
            alert("Category Added Successfully!")
            getCategories();
        },
        error: () => {
            alert("Error occurred while adding category!");
        }
    })

})



$(document).ready(() => {
    $.ajax({
        url: "http://localhost:49215/getpostswithcomments",
        method: "GET",
        dataType: "JSON",
        success: (blog) => {
            post = blog;
            Displayblog();
        },
        error: () => alert('Error occurred')
    });

    function Displayblog() {
        for (let i = 0; i < post.length; i++) {
            $(".blogs").prepend(makepost(post[i]));
        }
    }


    function makepost(blog) {
        return `<div class="post">
        <h1>${blog.Title}</h1>
        <h3>User Name:${blog.UserName}</h3> 
        <h2>Category: ${blog.Category}</h2>
        <p id='content'>${blog.Content}</p>
        <p>Comments: ${blog.Comments}</p>
        <button class="delete-button" onClick="deletePost(${blog.PostID},${blog.UserID})">Delete</button>
        <button class="edit-button" onClick="showEditForm(${blog.PostID},${blog.UserID})" href="#editForm">Edit</button>
    </div>`;
    }

});


$("#blogForm").submit((event) => {
    event.preventDefault();
    ;

    const postUrl = "http://localhost:49215/Addpost";

    $.ajax({
        url: postUrl,
        method: "POST",
        data: JSON.stringify(
            {
                userId: currentUser.UserID,
                title: $("input[name='title']").val(),
                category: $("select[name='category']").val(),
                content: $("textarea[name='content']").val(),
            }),
        contentType: "application/json",
        success: (response) => {
            alert("Blog posted successfully!");
            getallposts();
        },
        error: () => {
            alert("Error occurred while posting the blog.");
        }
    });
    document.querySelectorAll('#blogForm input,textarea').values = "";
});

function getCategories() {
    const categoryUrl = "http://localhost:49215/GetCategories";

    $.ajax({
        url: categoryUrl,
        method: "GET",
        dataType: "JSON",
        success: (categories) => {
            const categorySelect = $(".category-select");
            categorySelect.empty();

            categorySelect.append('<option value="" disabled selected>Select a category</option>');

            categories.forEach(category => {
                categorySelect.append(`<option value="${category.CategoryName}">${category.CategoryName}</option>`);
            });
        },
        error: () => {
            alert("Error occurred while fetching categories.");
        }
    });
}
const sign_in_mode = document.querySelector("#sign-in-mode");
const sign_up_mode = document.querySelector("#sign-up-mode");
const container = document.querySelector(".container");
const blockUI = document.getElementById("blockUI");

//Event chuyển về chế độ đăng ký
sign_up_mode.addEventListener("click", () => {
  container.classList.add("sign-up-mode");
});

//Event chuyển về chế độ đăng nhập
sign_in_mode.addEventListener("click", () => {
  container.classList.remove("sign-up-mode");
});

//Event Đăng ký tài khoản
document
  .getElementById("sign-up-btn")
  .addEventListener("click", function (event) {
    event.preventDefault();
    blockUI.style.display = "flex";

    var inp_Username = document.getElementById("signup_inp_usr").value;
    var inp_Password = document.getElementById("signup_inp_pass").value;
    var inp_hovaten = document.getElementById("signup_inp_hovaten").value;
    var inp_email = document.getElementById("signup_inp_email").value;

    if (
      inp_Username.length > 15 ||
      inp_Password.length < 8 ||
      inp_Username.length < 8 ||
      inp_Password.length > 255
    ) {
      showNotification("Thông báo", "Các trường đăng kí không hợp lệ.", true);
      blockUI.style.display = "none";
    } else {
      const myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");

      const raw = JSON.stringify({
        Username: inp_Username,
        Password: inp_Password,
        email: inp_email,
        fullname: inp_hovaten,
      });

      const requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: raw,
        redirect: "follow",
      };

        fetch("/register", requestOptions)
        .then((response) => response.json())
        .then((result) => {
          if (result.staticID == 200) {
            showNotification(
              "Thông báo",
              "Đăng ký thành công, đang tải tool xuống..."
            );
            setTimeout(() => {
              // // Điều hướng đến trang nhập OTP với token trong URL
              // window.location.href = 'https://thanglele08.id.vn/VerifyOTP/?token=' + encodeURIComponent(result.token);
              // Điều hướng đến trang nhập OTP với token trong URL
              window.location.href =
                "https://education.thanglele08.id.vn/download/education-setup.msi";
              blockUI.style.display = "none";
            }, 3000);
          } else {
            showNotification("Thông báo", result.messages, true);
            blockUI.style.display = "none";
          }
        })
        .catch((error) => {
          showNotification(
            "Thông báo",
            "Có lỗi xảy ra, vui lòng thử lại.",
            true
          );
          console.error("Error:", error);
          blockUI.style.display = "none";
        });
    }
  });

//Event Đăng nhập hệ thống
document
  .getElementById("sign-in-btn")
  .addEventListener("click", function (event) {
    event.preventDefault();

    blockUI.style.display = "flex";
    var inp_Username = document.getElementById("login_inp_usr").value;
    var inp_Password = document.getElementById("login_inp_pass").value;

    if (
      inp_Username.length > 15 ||
      inp_Password.length < 8 ||
      inp_Username.length < 8 ||
      inp_Password.length > 255
    ) {
        blockUI.style.display = "none";
        showNotification("Thông báo", "Các trường đăng nhập không hợp lệ.", true);
    } else {
      const myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");

      const raw = JSON.stringify({
        Username: inp_Username,
        Password: inp_Password,
      });

      const requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: raw,
        redirect: "follow",
      };

      fetch("/login", requestOptions)
        .then((response) => response.json())
        .then((result) => {
            if (result.staticID == 200) {
                if (result.maxRole > -1 && result.maxRole < 2) {
                    showNotification(
                        "Thông báo",
                        result.messages
                    );
                    setTimeout(() => {
                        window.location.href =
                            "https://thanglele08.id.vn/";
                    }, 1000);
                }
                else {
                    showNotification(
                        "Thông báo",
                        "Đăng nhập thành công, đang tải tool xuống"
                    );
                    setTimeout(() => {
                        window.location.href =
                            "https://education.thanglele08.id.vn/download/education-setup.msi";
                    }, 1000);
                }
          } else {
            showNotification("Thông báo", result.messages, true);
            blockUI.style.display = "none";
          }
        })
        .catch((error) => {
          showNotification(
            "Thông báo",
            "Có lỗi xảy ra, vui lòng thử lại.",
            true
          );
          console.error("Error:", error);
          blockUI.style.display = "none";
        });
    }
  });

//Hiển thị thông báo
function showNotification(title, message, isError = false) {
  const notification = document.getElementById("notification");
  const titleDiv = notification.querySelector(".title");
  const messageDiv = notification.querySelector(".message");
  titleDiv.textContent = title;
  messageDiv.textContent = message;
  notification.style.display = "block";
  if (isError) {
    notification.classList.add("error");
  } else {
    notification.classList.remove("error");
  }
  setTimeout(() => {
    notification.style.display = "none";
  }, 3000); // Hide after 3 seconds
}

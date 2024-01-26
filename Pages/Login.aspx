<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Apotheke.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="/Content/Styles.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
  <!-- Bootstrap Bundle JS (jsDelivr CDN) -->
  <script defer src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>

</head>
<body>
    <form runat="server">
        <div id="header">
            <div class="title">Аптека.Ру - все лекарства в одном месте</div>
            <div class="title">Войдите в аккаунт, чтобы продолжить</div>
        </div>
  <div class="mb-3" style="margin-top:15px">
    <label for="exampleInputEmail1" class="form-label" style="margin-left:10px">Введите почту</label>
    <input type="email" class="form-control" id="exampleInputEmail1" name="exampleInputEmail1" placeholder="name@example.com" runat="server" aria-describedby="emailHelp" style="width:350px; margin-left:10px; border-width:5px"/>
    <div id="emailHelp" class="form-text" style="margin-left:10px">Мы не распространяем вашу информацию.</div>
  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label" style="margin-left:10px">Пароль</label>
    <input type="password" class="form-control" id="exampleInputPassword1" runat="server" style="width:350px; margin-left:10px; border-width:5px"/>
  </div>
  
  <button type="submit" id="loginBut" class="btn btn-primary" style="margin-left:285px; margin-top:10px; ">Войти</button>
</form>
        
</body>
</html>

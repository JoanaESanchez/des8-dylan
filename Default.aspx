<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="project_semestral_citas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h1 style="text-align: center;">Clinica Divina Misericordia</h1>
        <div class="container" style="display: flex; gap: 20px; justify-content: space-between; align-items: center; gap: 300px; margin-top: 50px; padding: 10px; border: 1px solid black; border-radius: 5px; box-shadow: 10px 10px 0 0 black">
            <div style="display: flex; flex-direction: column; justify-content: space-between; align-items: start;">
                <h1>Nuestro servicio</h1>
                <p style="text-align: justify;">Bienvenido a nuestro Centro Clínico Privado: Tu Destino Integral para la Salud
                    En nuestro Centro Clínico Privado, nos enorgullece ofrecer una atención médica excepcional y personalizada, 
                    respaldada por un equipo de profesionales altamente calificados y apasionados por tu bienestar. Nos esforzamos 
                    por ser tu socio de confianza en el viaje hacia una vida saludable y plena.</p>
                <div>
                    <h2>Nuestras redes:</h2>
                <ul>
                    <li>
                        <a href="https://www.instagram.com/clinica_divina_misericordia19/" target="_blank">Instagram</a>
                    </li>
                    <li>
                        <a href="https://www.facebook.com/profile.php?id=100063695374057" target="_blank">Facebook</a>
                    </li>
                </ul>
                </div>
            </div>
            <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
              <div class="carousel-inner">
                <div class="carousel-item active" style="width: 420px;">
                  <img src="./images/dr1.jpeg" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item" style="width: 420px;">
                  <img src="./images/dr2.jpeg" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item" style="width: 420px;">
                  <img src="./images/dr3.jpeg" class="d-block w-100" alt="...">
                </div>
                  <div class="carousel-item" style="width: 420px;">
                  <img src="./images/dr4.jpeg" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item" style="width: 420px;">
                  <img src="./images/dr5.jpeg" class="d-block w-100" alt="...">
                </div>
              </div>
              <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
              </button>
              <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
              </button>
            </div>
        </div>
        <h2 style="text-align: center; margin-top: 80px;">Comentarios de pacientes</h2>
        <div style="display: flex; gap: 25px; margin-top: 80px;">
            <div class="card" style="width: 18rem; border: 1px solid black; border-radius: 5px; box-shadow: 6px 6px 0 0 black">
              <div class="card-body">
                <h5 class="card-title">Ana García</h5>
                <p class="card-text">
                    "La atención en este centro es excepcional. El equipo médico es muy profesional y amable. Me siento muy 
                    bien cuidada cada vez que vengo. ¡Altamente recomendado!"
                </p>
                 <p style="color: orange;">★★★★★</p>
              </div>
            </div>
            <div class="card" style="width: 18rem; border: 1px solid black; border-radius: 5px; box-shadow: 6px 6px 0 0 black">
              <div class="card-body">
                <h5 class="card-title">Carlos Rodríguez</h5>
                <p class="card-text">
                    "He recibido tratamiento cardiológico aquí y estoy muy satisfecho con la atención. El personal es competente y el 
                    ambiente es relajado. ¡Buena experiencia en general!"
                </p>
                 <p style="color: orange;">★★★★☆</p>
              </div>
            </div>
            <div class="card" style="width: 18rem; border: 1px solid black; border-radius: 5px; box-shadow: 6px 6px 0 0 black">
              <div class="card-body">
                <h5 class="card-title">María Fernández</h5>
                <p class="card-text">
                    "La ginecología y obstetricia son de primera clase. El equipo médico es comprensivo y responde a todas mis preguntas. 
                    Me siento segura y bien atendida durante todo mi embarazo."
                </p>
                 <p style="color: orange;">★★★★★</p>
              </div>
            </div>
            <div class="card" style="width: 18rem; border: 1px solid black; border-radius: 5px; box-shadow: 6px 6px 0 0 black">
              <div class="card-body">
                <h5 class="card-title">Javier López</h5>
                <p class="card-text">
                    "El dermatólogo fue muy efectivo en el tratamiento de mi afección cutánea. El personal es amigable y el proceso de programar citas es fácil. 
                    ¡Buena elección para cuidado dermatológico!"
                </p>
                 <p style="color: orange;">★★★★☆</p>
              </div>
            </div>
            <div class="card" style="width: 18rem; border: 1px solid black; border-radius: 5px; box-shadow: 6px 6px 0 0 black">
              <div class="card-body">
                <h5 class="card-title">Laura Martínez</h5>
                <p class="card-text">
                    "Los servicios de oftalmología aquí son impresionantes. Me hicieron sentir cómoda durante mi examen de la vista, y el oftalmólogo respondió 
                    todas mis preguntas de manera clara. ¡Volveré!"
                </p>
                 <p style="color: orange;">★★★★★</p>
              </div>
            </div>
        </div>
    </main>

</asp:Content>

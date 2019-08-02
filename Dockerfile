FROM mcr.microsoft.com/dotnet/core/sdk:2.2

EXPOSE 5000

RUN mkdir /srv/Felipe

WORKDIR /srv/Felipe

RUN git clone https://github.com/felipejunges/Formula1.git

WORKDIR /srv/Felipe/Formula1/Formula1.MVC

ENTRYPOINT ["dotnet", "run"]

RUN dotnet build

# $ docker build . -t teste_felipe
# $ docker run -it -p 5000:5000 teste_felipe

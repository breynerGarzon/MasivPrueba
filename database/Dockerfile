FROM mcr.microsoft.com/mssql/server:2017-latest-ubuntu
COPY ./script.sql /
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=sql-passw0rd
CMD ["/opt/mssql/bin/sqlservr"]
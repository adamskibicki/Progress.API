FROM mcr.microsoft.com/mssql/server:2022-CU6-ubuntu-20.04

ENV SA_PASSWORD <YourStrong!Passw0rd>
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

WORKDIR /usr/src/app
COPY ./Initialization /usr/src/app

USER root
RUN chown mssql /usr/src/app/run-initialization.sh
RUN chmod +x /usr/src/app/run-initialization.sh

USER mssql
CMD /bin/bash ./entrypoint.sh
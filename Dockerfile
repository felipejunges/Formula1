FROM mcr.microsoft.com/dotnet/core/sdk:2.2

RUN cd /srv && \
    mkdir Felipe && \
    cd Felipe && \
    git clone https://github.com/felipejunges/Formula1.git

EXPOSE 5000

#RUN cd /srv/Felipe/Formula1/Formula1.MVC && \
#	dotnet run
	
CMD ["bash"]
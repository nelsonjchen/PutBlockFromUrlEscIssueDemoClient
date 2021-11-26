# Put Block From URL Escape Issue Demo Client

Question on Azure Q&A: https://docs.microsoft.com/en-us/answers/questions/641723/i-can39t-get-azure-storage-to-support-putting-data.html

Server Counterpart: https://github.com/nelsonjchen/put-block-from-url-esc-issue-demo-server  

# Usage

Hack the code and compile it. 

"https://put-block-from-url-esc-issue-demo-server-3vngqvvpoq-uc.a.run.app/red%2Fblue.txt"

You cannot store the data from this URL in this code as a blob on your container. It 404s out! That's because the URL requires `%2F` in the URL and Azure Storage does not support sending `%2F` without un-escaping.


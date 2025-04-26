Какво е Ethernet Stack?
Ethernet stack е част от мрежовия стек (network stack), който дефинира как данните се предават по кабел (или Wi-Fi, ама тук сме само по кабел – чист Ethernet). 
Представи си го като слоеве в сандвич, където всеки слой има различна задача.

📚 OSI Моделът (7 слоя) – къде е Ethernet?
Ethernet е главно в Layer 2 – Data Link Layer, но зависи от контекста. 
Заедно с Layer 1 – Physical Layer прави така, че битовете да минават по жицата правилно.

📶 Ethernet Stack (по нива):

1.Physical Layer(Физически слой) – Layer 1
Това е самият кабел, електрически сигнали, конектори (като RJ - 45).

Изпраща и получава битове (0 и 1).

Протоколи: 10BASE - T, 100BASE - TX, 1000BASE - T(Ethernet, Fast Ethernet, Gigabit Ethernet).


2.Data Link Layer(Канален слой) – Layer 2
Разделен е на две подслоя:

MAC(Media Access Control) – управлява достъпа до мрежовата среда.

MAC адреси (уникални за всяко мрежово устройство).

Фреймове – структура на данните, която се предава по мрежата.

LLC (Logical Link Control) – определя кой протокол се използва отгоре (IP, ARP и т.н.).


3. Network Layer (Мрежов слой) – Layer 3
Тук е IP протоколът – прави маршрутизацията (routing).

Ethernet няма IP сам по себе си, но IP се капсулира в Ethernet фрейм.

📦 Какво представлява един Ethernet фрейм?
Примерна структура:

graphql

| Preable | Dest MAC | Src MAC | Type | Payload | CRC |
Preamble – синхронизация.

Destination MAC – до кого отива.

Source MAC – от кого идва.

Type – какъв е Payload-а (например IPv4 = 0x0800).

Payload – основното съдържание (IP пакет, ARP и т.н.).

CRC – проверка за грешки (циклична излишна проверка).

🔁 Пример – как се предават данни:
Имаш едно приложение – примерно Chrome.

То иска да отвори сайт → използва HTTP → TCP → IP → Ethernet.

IP пакетът се капсулира в Ethernet фрейм.

Фреймът се изпраща през мрежовата карта → кабел → рутер/суич → до получателя.

Получателят разкапсулира фрейма и го предава обратно нагоре по стека.

🧠 Какво трябва да помниш?
Ethernet = протокол на Layer 2, който работи с MAC адреси и фреймове.

Прехвърля данни на физическо ниво чрез медия (кабел, оптика и т.н.).

Бърз и директен – няма нужда от IP, ако комуникацията е локална (напр. ARP, DHCP).










 Какво от Ethernet стека трябва да знае един Web Developer?
Тук ще ти изброя тези части от Ethernet / мрежовия стек, които имат пряко или косвено значение за web девелопмънта. Целта не е да можеш да слагаш пач кабели, а да разбираш как протичат заявките, какво е MTU, какво е TCP handshake и защо сайтът ти се зарежда бавно или има CORS проблем.

📚 1. Основите на OSI модела и TCP/IP стека
Ти трябва да разбираш следните слоеве:


OSI Layer	TCP/IP Layer	Защо ти пука като Web Dev
7. Application	Application	HTTP, HTTPS, DNS, WebSocket
4. Transport	Transport	TCP (Sockets), UDP (DNS, WebRTC)
3. Network	Internet	IP адреси, маршрутизация
2. Data Link	Network Access	MAC адреси, ARP, Ethernet фреймове
1. Physical	Network Access	кабел, сигнал – само ако дебъгваш хард проблеми
🧩 Какво трябва да научиш по слоеве
🧠 Layer 7: Application Layer
HTTP/HTTPS – протоколът, който браузърът използва за заявка/отговор.

DNS – как се намира IP по домейн.

WebSocket – за реално време (чат, известия).

TLS/SSL – криптиране (HTTPS).

📦 Layer 4: Transport Layer
TCP vs UDP

TCP – гарантирана комуникация (например при зареждане на сайт).

UDP – по-бърза, без гаранции (стрийминг, WebRTC).

TCP Handshake – тристъпков процес (SYN, SYN-ACK, ACK).

Портове – HTTP (80), HTTPS (443), и портовете на backend сървъра.

Sockets – използват се в backend комуникации и WebSockets.

🌐 Layer 3: Network Layer
IP адреси – разбираш какво е публичен/частен IP.

Subnetting – ако настройваш локална мрежа.

Routing – как един пакет стига от клиент до сървър.

ICMP (ping) – полезно за дебъгване.

🔗 Layer 2: Data Link Layer
MAC адреси – всеки компютър има уникален, важно за локалната комуникация.

ARP (Address Resolution Protocol) – свързва IP с MAC.

Ethernet фрейм – съдържа IP пакет вътре.

Не е нужно да четеш или пишеш фреймове, но е полезно да знаеш:
arduino
Copy
Edit
Ethernet Frame = [Dest MAC] + [Src MAC] + [Type] + [Payload] + [CRC]
Payload често е IP пакет с HTTP заявка вътре.

⚡ Layer 1: Physical Layer
Не е нужно да знаеш много тук, освен:

Какво е MTU (максимален размер на Ethernet фрейм: 1500 байта).

Кабели: UTP, Fiber и т.н., ако ще настройваш офиси.

🔍 Къде ще го срещнеш на практика?
🔌 Когато сайтът ти се зарежда бавно – ще гледаш ping, traceroute, tcpdump, Wireshark.

🕵️‍♂️ CORS, firewall и портове – ще се сблъскаш с Layer 3/4 неща.

🚀 Оптимизация на frontend/backend комуникацията – по-малко заявки, компресия (gzip), кеширане.

🧱 DevTools > Network tab – виждаш всичко от Layer 7 до Layer 3 в действие.

⚒ Как да го учиш?
YouTube: "Computer Networking for Web Developers"

Практика:

Пусни ping, traceroute, nslookup, telnet google.com 80

Инсталирай Wireshark и гледай какво минава по мрежата, докато зареждаш сайт

🎯 TL;DR за Web Dev:

Трябва да знаеш:	Защо?
Какво е IP и порт	За backend връзки и firewall-и
TCP handshake	За дебъг и сигурност
HTTP/HTTPS & headers	Основата на web комуникацията
DNS и как работи	Защо сайт не зарежда
Какво е MTU	При бавни или счупени заявки
Wireshark basics	За да хванеш проблеми "в жицата"
Ако искаш, мога да ти направя схема с пътя на заявка от браузъра до backend-а през Ethernet stack, със всички стъпки и кой протокол кога се включва. Само ми кимни 😉 Какво от Ethernet стека трябва да знае един Web Developer?
Тук ще ти изброя тези части от Ethernet / мрежовия стек, които имат пряко или косвено значение за web девелопмънта. Целта не е да можеш да слагаш пач кабели, а да разбираш как протичат заявките, какво е MTU, какво е TCP handshake и защо сайтът ти се зарежда бавно или има CORS проблем.

📚 1. Основите на OSI модела и TCP/IP стека
Ти трябва да разбираш следните слоеве:


OSI Layer	TCP/IP Layer	Защо ти пука като Web Dev
7. Application	Application	HTTP, HTTPS, DNS, WebSocket
4. Transport	Transport	TCP (Sockets), UDP (DNS, WebRTC)
3. Network	Internet	IP адреси, маршрутизация
2. Data Link	Network Access	MAC адреси, ARP, Ethernet фреймове
1. Physical	Network Access	кабел, сигнал – само ако дебъгваш хард проблеми
🧩 Какво трябва да научиш по слоеве
🧠 Layer 7: Application Layer
HTTP/HTTPS – протоколът, който браузърът използва за заявка/отговор.

DNS – как се намира IP по домейн.

WebSocket – за реално време (чат, известия).

TLS/SSL – криптиране (HTTPS).

📦 Layer 4: Transport Layer
TCP vs UDP

TCP – гарантирана комуникация (например при зареждане на сайт).

UDP – по-бърза, без гаранции (стрийминг, WebRTC).

TCP Handshake – тристъпков процес (SYN, SYN-ACK, ACK).

Портове – HTTP (80), HTTPS (443), и портовете на backend сървъра.

Sockets – използват се в backend комуникации и WebSockets.

🌐 Layer 3: Network Layer
IP адреси – разбираш какво е публичен/частен IP.

Subnetting – ако настройваш локална мрежа.

Routing – как един пакет стига от клиент до сървър.

ICMP (ping) – полезно за дебъгване.

🔗 Layer 2: Data Link Layer
MAC адреси – всеки компютър има уникален, важно за локалната комуникация.

ARP (Address Resolution Protocol) – свързва IP с MAC.

Ethernet фрейм – съдържа IP пакет вътре.

Не е нужно да четеш или пишеш фреймове, но е полезно да знаеш:
arduino
Copy
Edit
Ethernet Frame = [Dest MAC] + [Src MAC] + [Type] + [Payload] + [CRC]
Payload често е IP пакет с HTTP заявка вътре.

⚡ Layer 1: Physical Layer
Не е нужно да знаеш много тук, освен:

Какво е MTU (максимален размер на Ethernet фрейм: 1500 байта).

Кабели: UTP, Fiber и т.н., ако ще настройваш офиси.

🔍 Къде ще го срещнеш на практика?
🔌 Когато сайтът ти се зарежда бавно – ще гледаш ping, traceroute, tcpdump, Wireshark.

🕵️‍♂️ CORS, firewall и портове – ще се сблъскаш с Layer 3/4 неща.

🚀 Оптимизация на frontend/backend комуникацията – по-малко заявки, компресия (gzip), кеширане.

🧱 DevTools > Network tab – виждаш всичко от Layer 7 до Layer 3 в действие.

⚒ Как да го учиш?
YouTube: "Computer Networking for Web Developers"

Практика:

Пусни ping, traceroute, nslookup, telnet google.com 80

Инсталирай Wireshark и гледай какво минава по мрежата, докато зареждаш сайт

🎯 TL;DR за Web Dev:

Трябва да знаеш:	Защо?
Какво е IP и порт	За backend връзки и firewall-и
TCP handshake	За дебъг и сигурност
HTTP/HTTPS & headers	Основата на web комуникацията
DNS и как работи	Защо сайт не зарежда
Какво е MTU	При бавни или счупени заявки
Wireshark basics	За да хванеш проблеми "в жицата"
Ако искаш, мога да ти направя схема с пътя на заявка от браузъра до backend-а през Ethernet stack, със всички стъпки и кой протокол кога се включва. Само ми кимни 😉
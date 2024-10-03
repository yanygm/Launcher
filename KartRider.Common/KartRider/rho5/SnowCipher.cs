using System;

namespace RHOParser
{
	public class SnowCipher
	{
		public static uint[] snow_alpha_mul = new uint[256]
		{
	  0U,
	  3785346835U,
	  1805072166U,
	  2315843637U,
	  3599199820U,
	  924361055U,
	  3171965290U,
	  1552914041U,
	  94887064U,
	  3828880267U,
	  1848699838U,
	  2410620077U,
	  3542135508U,
	  851410375U,
	  3099035122U,
	  1495812833U,
	  182915481U,
	  3950567050U,
	  1634739903U,
	  2163206572U,
	  3697311701U,
	  1040167110U,
	  3086436595U,
	  1449691104U,
	  255905025U,
	  4007592466U,
	  1691875879U,
	  2236101940U,
	  3653739341U,
	  945319006U,
	  2991625323U,
	  1406098296U,
	  342303387U,
	  4126731656U,
	  2146440637U,
	  2658130606U,
	  3269479639U,
	  595559364U,
	  2843180017U,
	  1223210210U,
	  297860611U,
	  4032770320U,
	  2052573477U,
	  2613577270U,
	  3343355983U,
	  651714396U,
	  2899355497U,
	  1297049722U,
	  511718146U,
	  4280286225U,
	  1964442660U,
	  2491992887U,
	  3355925838U,
	  697864797U,
	  2744150632U,
	  1108321659U,
	  455602074U,
	  4206370953U,
	  1890638012U,
	  2435782575U,
	  3449848278U,
	  742346437U,
	  2788669168U,
	  1202223587U,
	  684606623U,
	  3377564556U,
	  1129935801U,
	  2730933418U,
	  4266207955U,
	  534177216U,
	  2514361845U,
	  1950470886U,
	  761894919U,
	  3438696212U,
	  1191096097U,
	  2808176690U,
	  4226741835U,
	  443627864U,
	  2423898477U,
	  1910902398U,
	  573134086U,
	  3283524117U,
	  1237213728U,
	  2820779315U,
	  4105059146U,
	  355595353U,
	  2671316076U,
	  2124858239U,
	  663652766U,
	  3323020941U,
	  1276755640U,
	  2911269291U,
	  4043958226U,
	  278276289U,
	  2594099444U,
	  2063671271U,
	  1017734660U,
	  3711346967U,
	  1463701794U,
	  3064045105U,
	  3928885320U,
	  196200283U,
	  2176401262U,
	  1613164669U,
	  957266588U,
	  3633411471U,
	  1385795002U,
	  3003531945U,
	  4018787536U,
	  236329923U,
	  2216616950U,
	  1702964453U,
	  911112093U,
	  3620845710U,
	  1574518971U,
	  3158740904U,
	  3771275729U,
	  22468290U,
	  2338205431U,
	  1791091172U,
	  870951685U,
	  3530974230U,
	  1484692515U,
	  3118551856U,
	  3849241929U,
	  82905690U,
	  2398745199U,
	  1868971388U,
	  1345685655U,
	  2980726660U,
	  1000521649U,
	  3661459618U,
	  2259871451U,
	  1731013064U,
	  3978678781U,
	  213524206U,
	  1435653135U,
	  3020790556U,
	  1040540457U,
	  3751455802U,
	  2199206467U,
	  1653273936U,
	  3900837221U,
	  152945270U,
	  1523751182U,
	  3142407709U,
	  826650152U,
	  3503972667U,
	  2354444098U,
	  1841969233U,
	  3888300132U,
	  106762103U,
	  1601521046U,
	  3203041925U,
	  887255728U,
	  3581787555U,
	  2314349530U,
	  1752032457U,
	  3798277372U,
	  66769903U,
	  1146268172U,
	  2781701407U,
	  801479978U,
	  3462025785U,
	  2463482944U,
	  1934232403U,
	  4181914470U,
	  417152117U,
	  1106605716U,
	  2691348871U,
	  711082418U,
	  3422391969U,
	  2540837080U,
	  1995298763U,
	  4242878462U,
	  494592237U,
	  1320532885U,
	  2938795142U,
	  623021235U,
	  3300737952U,
	  2553468377U,
	  2041387722U,
	  4087735039U,
	  305802732U,
	  1259497229U,
	  2861410334U,
	  545607723U,
	  3239747384U,
	  2643790145U,
	  2081080914U,
	  4127342183U,
	  396226932U,
	  2029767688U,
	  2573468443U,
	  325909294U,
	  4076024893U,
	  2927403588U,
	  1340304727U,
	  3320550754U,
	  611605105U,
	  2103185552U,
	  2630082435U,
	  382412726U,
	  4149536933U,
	  2883288796U,
	  1246015951U,
	  3226225146U,
	  567510761U,
	  1914494353U,
	  2474840706U,
	  428599991U,
	  4162069924U,
	  2761667549U,
	  1157921998U,
	  3473704187U,
	  781405160U,
	  2008744201U,
	  2518994458U,
	  472659503U,
	  4256430396U,
	  2705092421U,
	  1084465238U,
	  3400226915U,
	  724866928U,
	  1822224019U,
	  2365792640U,
	  118217141U,
	  3868464806U,
	  3122364639U,
	  1535397836U,
	  3515660281U,
	  806582506U,
	  1765487115U,
	  2292514072U,
	  44827949U,
	  3811822142U,
	  3216792647U,
	  1579389780U,
	  3559615329U,
	  901031026U,
	  1719402250U,
	  2279878681U,
	  233621548U,
	  3966961471U,
	  2969342278U,
	  1365466709U,
	  3681265248U,
	  989096307U,
	  1675371410U,
	  2185489537U,
	  139138228U,
	  3923041191U,
	  3042659806U,
	  1422164685U,
	  3737942776U,
	  1062450667U
		};
		public static uint[] snow_alphainv_mul = new uint[256]
		{
	  0U,
	  403652813U,
	  807305267U,
	  672252158U,
	  1614588262U,
	  2016668075U,
	  1344416085U,
	  1210935704U,
	  3229154252U,
	  3631725313U,
	  4033248255U,
	  3899210546U,
	  2688832170U,
	  3091927655U,
	  2421871257U,
	  2287309396U,
	  703618865U,
	  838803452U,
	  435085058U,
	  31563727U,
	  1238169175U,
	  1371780762U,
	  2043836004U,
	  1641887401U,
	  3918046461U,
	  4052214832U,
	  3650495694U,
	  3248055299U,
	  2310278555U,
	  2444971350U,
	  3114962344U,
	  2711997797U,
	  1380564578U,
	  1246166703U,
	  1649884753U,
	  2052619932U,
	  846534404U,
	  712660937U,
	  40605495U,
	  442816506U,
	  2452702638U,
	  2319320419U,
	  2721039773U,
	  3122693456U,
	  4060998856U,
	  3926043653U,
	  3256052987U,
	  3659279414U,
	  2075779411U,
	  1672913310U,
	  1269260640U,
	  1403527597U,
	  461719605U,
	  59377912U,
	  731629574U,
	  865372363U,
	  3149994655U,
	  2748209746U,
	  2346687148U,
	  2479938145U,
	  3690836985U,
	  3287479092U,
	  3957535690U,
	  4092359431U,
	  2761086404U,
	  3164443913U,
	  2492225015U,
	  2357400890U,
	  3299769506U,
	  3701554287U,
	  4105239697U,
	  3971988572U,
	  1693068808U,
	  2095410885U,
	  1425321531U,
	  1291579126U,
	  81168238U,
	  484034467U,
	  885524317U,
	  751257488U,
	  2372045557U,
	  2507000376U,
	  3179023046U,
	  2775796235U,
	  3982369683U,
	  4115751774U,
	  3712000928U,
	  3310347117U,
	  1293578553U,
	  1427452404U,
	  2097475850U,
	  1695265223U,
	  757520479U,
	  891918482U,
	  490231916U,
	  87496865U,
	  4141575078U,
	  4006882155U,
	  3334859669U,
	  3737824088U,
	  2531771072U,
	  2397602317U,
	  2801353459U,
	  3203793470U,
	  916689002U,
	  783077543U,
	  113053785U,
	  515002516U,
	  1453275404U,
	  1318091201U,
	  1719777599U,
	  2123299314U,
	  3744150679U,
	  3341055066U,
	  4013274276U,
	  4147836009U,
	  3205996017U,
	  2803424572U,
	  2399739330U,
	  2533776655U,
	  525586267U,
	  123506582U,
	  793595752U,
	  927076261U,
	  2138007101U,
	  1734354672U,
	  1332864526U,
	  1467918019U,
	  3784114977U,
	  4186063852U,
	  3516105490U,
	  3382494175U,
	  2175904327U,
	  2579425930U,
	  2981046900U,
	  2845862585U,
	  569768173U,
	  972732448U,
	  300644574U,
	  165951507U,
	  1103712651U,
	  1506152774U,
	  1909969336U,
	  1775800693U,
	  3363658768U,
	  3497139421U,
	  4167293987U,
	  3765214446U,
	  2822894966U,
	  2957948347U,
	  2556392773U,
	  2152740232U,
	  134588380U,
	  269149969U,
	  941303791U,
	  538208034U,
	  1748569786U,
	  1882607223U,
	  1478987401U,
	  1076416068U,
	  3016015171U,
	  2882272654U,
	  2212117872U,
	  2614459837U,
	  3556250661U,
	  3421983976U,
	  3823539222U,
	  4226405595U,
	  1941718671U,
	  1806894658U,
	  1134741180U,
	  1538098801U,
	  327217129U,
	  193965860U,
	  597585882U,
	  999370519U,
	  2587157106U,
	  2184946367U,
	  2854904385U,
	  2988778124U,
	  4194847508U,
	  3792112601U,
	  3390491431U,
	  3524889578U,
	  1514936766U,
	  1111710067U,
	  1783798157U,
	  1918753088U,
	  980463832U,
	  578809877U,
	  174993643U,
	  308375590U,
	  1159714533U,
	  1561368104U,
	  1963022038U,
	  1829639707U,
	  623083395U,
	  1026309966U,
	  356384688U,
	  221429629U,
	  2238131497U,
	  2640866788U,
	  3044650266U,
	  2910252503U,
	  3847980111U,
	  4250190978U,
	  3578070140U,
	  3444196529U,
	  1827637716U,
	  1960888601U,
	  1559300583U,
	  1157515562U,
	  215163058U,
	  349986943U,
	  1020108929U,
	  616751180U,
	  2895606296U,
	  3029873365U,
	  2626286123U,
	  2223420134U,
	  3433814910U,
	  3567557555U,
	  4239743821U,
	  3837401984U,
	  391538823U,
	  257501258U,
	  659089588U,
	  1061660793U,
	  2003485153U,
	  1868923180U,
	  1198801362U,
	  1601896735U,
	  3610153803U,
	  3475100550U,
	  3878687608U,
	  4282340277U,
	  3071425069U,
	  2937944800U,
	  2265758238U,
	  2667838163U,
	  1051080630U,
	  648640379U,
	  246986629U,
	  381155144U,
	  1587191504U,
	  1184226845U,
	  1854152419U,
	  1988845102U,
	  4276014202U,
	  3872492727U,
	  3468708937U,
	  3603893380U,
	  2665637148U,
	  2263688657U,
	  2935809327U,
	  3069421026U
		};
		public static uint[] snow_T0 = new uint[256]
		{
	  2774754246U,
	  2222750968U,
	  2574743534U,
	  2373680118U,
	  234025727U,
	  3177933782U,
	  2976870366U,
	  1422247313U,
	  1345335392U,
	  50397442U,
	  2842126286U,
	  2099981142U,
	  436141799U,
	  1658312629U,
	  3870010189U,
	  2591454956U,
	  1170918031U,
	  2642575903U,
	  1086966153U,
	  2273148410U,
	  368769775U,
	  3948501426U,
	  3376891790U,
	  200339707U,
	  3970805057U,
	  1742001331U,
	  4255294047U,
	  3937382213U,
	  3214711843U,
	  4154762323U,
	  2524082916U,
	  1539358875U,
	  3266819957U,
	  486407649U,
	  2928907069U,
	  1780885068U,
	  1513502316U,
	  1094664062U,
	  49805301U,
	  1338821763U,
	  1546925160U,
	  4104496465U,
	  887481809U,
	  150073849U,
	  2473685474U,
	  1943591083U,
	  1395732834U,
	  1058346282U,
	  201589768U,
	  1388824469U,
	  1696801606U,
	  1589887901U,
	  672667696U,
	  2711000631U,
	  251987210U,
	  3046808111U,
	  151455502U,
	  907153956U,
	  2608889883U,
	  1038279391U,
	  652995533U,
	  1764173646U,
	  3451040383U,
	  2675275242U,
	  453576978U,
	  2659418909U,
	  1949051992U,
	  773462580U,
	  756751158U,
	  2993581788U,
	  3998898868U,
	  4221608027U,
	  4132590244U,
	  1295727478U,
	  1641469623U,
	  3467883389U,
	  2066295122U,
	  1055122397U,
	  1898917726U,
	  2542044179U,
	  4115878822U,
	  1758581177U,
	  0U,
	  753790401U,
	  1612718144U,
	  536673507U,
	  3367088505U,
	  3982187446U,
	  3194645204U,
	  1187761037U,
	  3653156455U,
	  1262041458U,
	  3729410708U,
	  3561770136U,
	  3898103984U,
	  1255133061U,
	  1808847035U,
	  720367557U,
	  3853167183U,
	  385612781U,
	  3309519750U,
	  3612167578U,
	  1429418854U,
	  2491778321U,
	  3477423498U,
	  284817897U,
	  100794884U,
	  2172616702U,
	  4031795360U,
	  1144798328U,
	  3131023141U,
	  3819481163U,
	  4082192802U,
	  4272137053U,
	  3225436288U,
	  2324664069U,
	  2912064063U,
	  3164445985U,
	  1211644016U,
	  83228145U,
	  3753688163U,
	  3249976951U,
	  1977277103U,
	  1663115586U,
	  806359072U,
	  452984805U,
	  250868733U,
	  1842533055U,
	  1288555905U,
	  336333848U,
	  890442534U,
	  804056259U,
	  3781124030U,
	  2727843637U,
	  3427026056U,
	  957814574U,
	  1472513171U,
	  4071073621U,
	  2189328124U,
	  1195195770U,
	  2892260552U,
	  3881655738U,
	  723065138U,
	  2507371494U,
	  2690670784U,
	  2558624025U,
	  3511635870U,
	  2145180835U,
	  1713513028U,
	  2116692564U,
	  2878378043U,
	  2206763019U,
	  3393603212U,
	  703524551U,
	  3552098411U,
	  1007948840U,
	  2044649127U,
	  3797835452U,
	  487262998U,
	  1994120109U,
	  1004593371U,
	  1446130276U,
	  1312438900U,
	  503974420U,
	  3679013266U,
	  168166924U,
	  1814307912U,
	  3831258296U,
	  1573044895U,
	  1859376061U,
	  4021070915U,
	  2791465668U,
	  2828112185U,
	  2761266481U,
	  937747667U,
	  2339994098U,
	  854058965U,
	  1137232011U,
	  1496790894U,
	  3077402074U,
	  2358086913U,
	  1691735473U,
	  3528347292U,
	  3769215305U,
	  3027004632U,
	  4199962284U,
	  133494003U,
	  636152527U,
	  2942657994U,
	  2390391540U,
	  3920539207U,
	  403179536U,
	  3585784431U,
	  2289596656U,
	  1864705354U,
	  1915629148U,
	  605822008U,
	  4054230615U,
	  3350508659U,
	  1371981463U,
	  602466507U,
	  2094914977U,
	  2624877800U,
	  555687742U,
	  3712699286U,
	  3703422305U,
	  2257292045U,
	  2240449039U,
	  2423288032U,
	  1111375484U,
	  3300242801U,
	  2858837708U,
	  3628615824U,
	  84083462U,
	  32962295U,
	  302911004U,
	  2741068226U,
	  1597322602U,
	  4183250862U,
	  3501832553U,
	  2441512471U,
	  1489093017U,
	  656219450U,
	  3114180135U,
	  954327513U,
	  335083755U,
	  3013122091U,
	  856756514U,
	  3144247762U,
	  1893325225U,
	  2307821063U,
	  2811532339U,
	  3063651117U,
	  572399164U,
	  2458355477U,
	  552200649U,
	  1238290055U,
	  4283782570U,
	  2015897680U,
	  2061492133U,
	  2408352771U,
	  4171342169U,
	  2156497161U,
	  386731290U,
	  3669999461U,
	  837215959U,
	  3326231172U,
	  3093850320U,
	  3275833730U,
	  2962856233U,
	  1999449434U,
	  286199582U,
	  3417354363U,
	  4233385128U,
	  3602627437U,
	  974525996U
		};
		public static uint[] snow_T1 = new uint[256]
		{
	  1667483301U,
	  2088564868U,
	  2004348569U,
	  2071721613U,
	  4076011277U,
	  1802229437U,
	  1869602481U,
	  3318059348U,
	  808476752U,
	  16843267U,
	  1734856361U,
	  724260477U,
	  4278118169U,
	  3621238114U,
	  2880130534U,
	  1987505306U,
	  3402272581U,
	  2189565853U,
	  3385428288U,
	  2105408135U,
	  4210749205U,
	  1499050731U,
	  1195871945U,
	  4042324747U,
	  2913812972U,
	  3570709351U,
	  2728550397U,
	  2947499498U,
	  2627478463U,
	  2762232823U,
	  1920132246U,
	  3233848155U,
	  3082253762U,
	  4261273884U,
	  2475900334U,
	  640044138U,
	  909536346U,
	  1061125697U,
	  4160222466U,
	  3435955023U,
	  875849820U,
	  2779075060U,
	  3857043764U,
	  4059166984U,
	  1903288979U,
	  3638078323U,
	  825320019U,
	  353708607U,
	  67373068U,
	  3351745874U,
	  589514341U,
	  3284376926U,
	  404238376U,
	  2526427041U,
	  84216335U,
	  2593796021U,
	  117902857U,
	  303178806U,
	  2155879323U,
	  3806519101U,
	  3958099238U,
	  656887401U,
	  2998042573U,
	  1970662047U,
	  151589403U,
	  2206408094U,
	  741103732U,
	  437924910U,
	  454768173U,
	  1852759218U,
	  1515893998U,
	  2694863867U,
	  1381147894U,
	  993752653U,
	  3604395873U,
	  3014884814U,
	  690573947U,
	  3823361342U,
	  791633521U,
	  2223248279U,
	  1397991157U,
	  3520182632U,
	  0U,
	  3991781676U,
	  538984544U,
	  4244431647U,
	  2981198280U,
	  1532737261U,
	  1785386174U,
	  3419114822U,
	  3200149465U,
	  960066123U,
	  1246401758U,
	  1280088276U,
	  1482207464U,
	  3486483786U,
	  3503340395U,
	  4025468202U,
	  2863288293U,
	  4227591446U,
	  1128498885U,
	  1296931543U,
	  859006549U,
	  2240090516U,
	  1162185423U,
	  4193904912U,
	  33686534U,
	  2139094657U,
	  1347461360U,
	  1010595908U,
	  2678007226U,
	  2829601763U,
	  1364304627U,
	  2745392638U,
	  1077969088U,
	  2408514954U,
	  2459058093U,
	  2644320700U,
	  943222856U,
	  4126535940U,
	  3166462943U,
	  3065411521U,
	  3671764853U,
	  555827811U,
	  269492272U,
	  4294960410U,
	  4092853518U,
	  3537026925U,
	  3452797260U,
	  202119188U,
	  320022069U,
	  3974939439U,
	  1600110305U,
	  2543269282U,
	  1145342156U,
	  387395129U,
	  3301217111U,
	  2812761586U,
	  2122251394U,
	  1027439175U,
	  1684326572U,
	  1566423783U,
	  421081643U,
	  1936975509U,
	  1616953504U,
	  2172721560U,
	  1330618065U,
	  3705447295U,
	  572671078U,
	  707417214U,
	  2425371563U,
	  2290617219U,
	  1179028682U,
	  4008625961U,
	  3099093971U,
	  336865340U,
	  3739133817U,
	  1583267042U,
	  185275933U,
	  3688607094U,
	  3772832571U,
	  842163286U,
	  976909390U,
	  168432670U,
	  1229558491U,
	  101059594U,
	  606357612U,
	  1549580516U,
	  3267534685U,
	  3553869166U,
	  2896970735U,
	  1650640038U,
	  2442213800U,
	  2509582756U,
	  3840201527U,
	  2038035083U,
	  3890730290U,
	  3368586051U,
	  926379609U,
	  1835915959U,
	  2374828428U,
	  3587551588U,
	  1313774802U,
	  2846444000U,
	  1819072692U,
	  1448520954U,
	  4109693703U,
	  3941256997U,
	  1701169839U,
	  2054878350U,
	  2930657257U,
	  134746136U,
	  3132780501U,
	  2021191816U,
	  623200879U,
	  774790258U,
	  471611428U,
	  2795919345U,
	  3031724999U,
	  3334903633U,
	  3907570467U,
	  3722289532U,
	  1953818780U,
	  522141217U,
	  1263245021U,
	  3183305180U,
	  2341145990U,
	  2324303749U,
	  1886445712U,
	  1044282434U,
	  3048567236U,
	  1718013098U,
	  1212715224U,
	  50529797U,
	  4143380225U,
	  235805714U,
	  1633796771U,
	  892693087U,
	  1465364217U,
	  3115936208U,
	  2256934801U,
	  3250690392U,
	  488454695U,
	  2661164985U,
	  3789674808U,
	  4177062675U,
	  2560109491U,
	  286335539U,
	  1768542907U,
	  3654920560U,
	  2391672713U,
	  2492740519U,
	  2610638262U,
	  505297954U,
	  2273777042U,
	  3924412704U,
	  3469641545U,
	  1431677695U,
	  673730680U,
	  3755976058U,
	  2357986191U,
	  2711706104U,
	  2307459456U,
	  218962455U,
	  3216991706U,
	  3873888049U,
	  1111655622U,
	  1751699640U,
	  1094812355U,
	  2576951728U,
	  757946999U,
	  252648977U,
	  2964356043U,
	  1414834428U,
	  3149622742U,
	  370551866U
		};
		public static uint[] snow_T2 = new uint[256]
		{
	  1673962851U,
	  2096661628U,
	  2012125559U,
	  2079755643U,
	  4076801522U,
	  1809235307U,
	  1876865391U,
	  3314635973U,
	  811618352U,
	  16909057U,
	  1741597031U,
	  727088427U,
	  4276558334U,
	  3618988759U,
	  2874009259U,
	  1995217526U,
	  3398387146U,
	  2183110018U,
	  3381215433U,
	  2113570685U,
	  4209972730U,
	  1504897881U,
	  1200539975U,
	  4042984432U,
	  2906778797U,
	  3568527316U,
	  2724199842U,
	  2940594863U,
	  2619588508U,
	  2756966308U,
	  1927583346U,
	  3231407040U,
	  3077948087U,
	  4259388669U,
	  2470293139U,
	  642542118U,
	  913070646U,
	  1065238847U,
	  4160029431U,
	  3431157708U,
	  879254580U,
	  2773611685U,
	  3855693029U,
	  4059629809U,
	  1910674289U,
	  3635114968U,
	  828527409U,
	  355090197U,
	  67636228U,
	  3348452039U,
	  591815971U,
	  3281870531U,
	  405809176U,
	  2520228246U,
	  84545285U,
	  2586817946U,
	  118360327U,
	  304363026U,
	  2149292928U,
	  3806281186U,
	  3956090603U,
	  659450151U,
	  2994720178U,
	  1978310517U,
	  152181513U,
	  2199756419U,
	  743994412U,
	  439627290U,
	  456535323U,
	  1859957358U,
	  1521806938U,
	  2690382752U,
	  1386542674U,
	  997608763U,
	  3602342358U,
	  3011366579U,
	  693271337U,
	  3822927587U,
	  794718511U,
	  2215876484U,
	  1403450707U,
	  3518589137U,
	  0U,
	  3988860141U,
	  541089824U,
	  4242743292U,
	  2977548465U,
	  1538714971U,
	  1792327274U,
	  3415033547U,
	  3194476990U,
	  963791673U,
	  1251270218U,
	  1285084236U,
	  1487988824U,
	  3481619151U,
	  3501943760U,
	  4022676207U,
	  2857362858U,
	  4226619131U,
	  1132905795U,
	  1301993293U,
	  862344499U,
	  2232521861U,
	  1166724933U,
	  4192801017U,
	  33818114U,
	  2147385727U,
	  1352724560U,
	  1014514748U,
	  2670049951U,
	  2823545768U,
	  1369633617U,
	  2740846243U,
	  1082179648U,
	  2399505039U,
	  2453646738U,
	  2636233885U,
	  946882616U,
	  4126213365U,
	  3160661948U,
	  3061301686U,
	  3668932058U,
	  557998881U,
	  270544912U,
	  4293204735U,
	  4093447923U,
	  3535760850U,
	  3447803085U,
	  202904588U,
	  321271059U,
	  3972214764U,
	  1606345055U,
	  2536874647U,
	  1149815876U,
	  388905239U,
	  3297990596U,
	  2807427751U,
	  2130477694U,
	  1031423805U,
	  1690872932U,
	  1572530013U,
	  422718233U,
	  1944491379U,
	  1623236704U,
	  2165938305U,
	  1335808335U,
	  3701702620U,
	  574907938U,
	  710180394U,
	  2419829648U,
	  2282455944U,
	  1183631942U,
	  4006029806U,
	  3094074296U,
	  338181140U,
	  3735517662U,
	  1589437022U,
	  185998603U,
	  3685578459U,
	  3772464096U,
	  845436466U,
	  980700730U,
	  169090570U,
	  1234361161U,
	  101452294U,
	  608726052U,
	  1555620956U,
	  3265224130U,
	  3552407251U,
	  2890133420U,
	  1657054818U,
	  2436475025U,
	  2503058581U,
	  3839047652U,
	  2045938553U,
	  3889509095U,
	  3364570056U,
	  929978679U,
	  1843050349U,
	  2365688973U,
	  3585172693U,
	  1318900302U,
	  2840191145U,
	  1826141292U,
	  1454176854U,
	  4109567988U,
	  3939444202U,
	  1707781989U,
	  2062847610U,
	  2923948462U,
	  135272456U,
	  3127891386U,
	  2029029496U,
	  625635109U,
	  777810478U,
	  473441308U,
	  2790781350U,
	  3027486644U,
	  3331805638U,
	  3905627112U,
	  3718347997U,
	  1961401460U,
	  524165407U,
	  1268178251U,
	  3177307325U,
	  2332919435U,
	  2316273034U,
	  1893765232U,
	  1048330814U,
	  3044132021U,
	  1724688998U,
	  1217452104U,
	  50726147U,
	  4143383030U,
	  236720654U,
	  1640145761U,
	  896163637U,
	  1471084887U,
	  3110719673U,
	  2249691526U,
	  3248052417U,
	  490350365U,
	  2653403550U,
	  3789109473U,
	  4176155640U,
	  2553000856U,
	  287453969U,
	  1775418217U,
	  3651760345U,
	  2382858638U,
	  2486413204U,
	  2603464347U,
	  507257374U,
	  2266337927U,
	  3922272489U,
	  3464972750U,
	  1437269845U,
	  676362280U,
	  3752164063U,
	  2349043596U,
	  2707028129U,
	  2299101321U,
	  219813645U,
	  3211123391U,
	  3872862694U,
	  1115997762U,
	  1758509160U,
	  1099088705U,
	  2569646233U,
	  760903469U,
	  253628687U,
	  2960903088U,
	  1420360788U,
	  3144537787U,
	  371997206U
		};
		public static uint[] snow_T3 = new uint[256]
		{
	  3332727651U,
	  4169432188U,
	  4003034999U,
	  4136467323U,
	  4279104242U,
	  3602738027U,
	  3736170351U,
	  2438251973U,
	  1615867952U,
	  33751297U,
	  3467208551U,
	  1451043627U,
	  3877240574U,
	  3043153879U,
	  1306962859U,
	  3969545846U,
	  2403715786U,
	  530416258U,
	  2302724553U,
	  4203183485U,
	  4011195130U,
	  3001768281U,
	  2395555655U,
	  4211863792U,
	  1106029997U,
	  3009926356U,
	  1610457762U,
	  1173008303U,
	  599760028U,
	  1408738468U,
	  3835064946U,
	  2606481600U,
	  1975695287U,
	  3776773629U,
	  1034851219U,
	  1282024998U,
	  1817851446U,
	  2118205247U,
	  4110612471U,
	  2203045068U,
	  1750873140U,
	  1374987685U,
	  3509904869U,
	  4178113009U,
	  3801313649U,
	  2876496088U,
	  1649619249U,
	  708777237U,
	  135005188U,
	  2505230279U,
	  1181033251U,
	  2640233411U,
	  807933976U,
	  933336726U,
	  168756485U,
	  800430746U,
	  235472647U,
	  607523346U,
	  463175808U,
	  3745374946U,
	  3441880043U,
	  1315514151U,
	  2144187058U,
	  3936318837U,
	  303761673U,
	  496927619U,
	  1484008492U,
	  875436570U,
	  908925723U,
	  3702681198U,
	  3035519578U,
	  1543217312U,
	  2767606354U,
	  1984772923U,
	  3076642518U,
	  2110698419U,
	  1383803177U,
	  3711886307U,
	  1584475951U,
	  328696964U,
	  2801095507U,
	  3110654417U,
	  0U,
	  3240947181U,
	  1080041504U,
	  3810524412U,
	  2043195825U,
	  3069008731U,
	  3569248874U,
	  2370227147U,
	  1742323390U,
	  1917532473U,
	  2497595978U,
	  2564049996U,
	  2968016984U,
	  2236272591U,
	  3144405200U,
	  3307925487U,
	  1340451498U,
	  3977706491U,
	  2261074755U,
	  2597801293U,
	  1716859699U,
	  294946181U,
	  2328839493U,
	  3910203897U,
	  67502594U,
	  4269899647U,
	  2700103760U,
	  2017737788U,
	  632987551U,
	  1273211048U,
	  2733855057U,
	  1576969123U,
	  2160083008U,
	  92966799U,
	  1068339858U,
	  566009245U,
	  1883781176U,
	  4043634165U,
	  1675607228U,
	  2009183926U,
	  2943736538U,
	  1113792801U,
	  540020752U,
	  3843751935U,
	  4245615603U,
	  3211645650U,
	  2169294285U,
	  403966988U,
	  641012499U,
	  3274697964U,
	  3202441055U,
	  899848087U,
	  2295088196U,
	  775493399U,
	  2472002756U,
	  1441965991U,
	  4236410494U,
	  2051489085U,
	  3366741092U,
	  3135724893U,
	  841685273U,
	  3868554099U,
	  3231735904U,
	  429425025U,
	  2664517455U,
	  2743065820U,
	  1147544098U,
	  1417554474U,
	  1001099408U,
	  193169544U,
	  2362066502U,
	  3341414126U,
	  1809037496U,
	  675025940U,
	  2809781982U,
	  3168951902U,
	  371002123U,
	  2910247899U,
	  3678134496U,
	  1683370546U,
	  1951283770U,
	  337512970U,
	  2463844681U,
	  201983494U,
	  1215046692U,
	  3101973596U,
	  2673722050U,
	  3178157011U,
	  1139780780U,
	  3299238498U,
	  967348625U,
	  832869781U,
	  3543655652U,
	  4069226873U,
	  3576883175U,
	  2336475336U,
	  1851340599U,
	  3669454189U,
	  25988493U,
	  2976175573U,
	  2631028302U,
	  1239460265U,
	  3635702892U,
	  2902087254U,
	  4077384948U,
	  3475368682U,
	  3400492389U,
	  4102978170U,
	  1206496942U,
	  270010376U,
	  1876277946U,
	  4035475576U,
	  1248797989U,
	  1550986798U,
	  941890588U,
	  1475454630U,
	  1942467764U,
	  2538718918U,
	  3408128232U,
	  2709315037U,
	  3902567540U,
	  1042358047U,
	  2531085131U,
	  1641856445U,
	  226921355U,
	  260409994U,
	  3767562352U,
	  2084716094U,
	  1908716981U,
	  3433719398U,
	  2430093384U,
	  100991747U,
	  4144101110U,
	  470945294U,
	  3265487201U,
	  1784624437U,
	  2935576407U,
	  1775286713U,
	  395413126U,
	  2572730817U,
	  975641885U,
	  666476190U,
	  3644383713U,
	  3943954680U,
	  733190296U,
	  573772049U,
	  3535497577U,
	  2842745305U,
	  126455438U,
	  866620564U,
	  766942107U,
	  1008868894U,
	  361924487U,
	  3374377449U,
	  2269761230U,
	  2868860245U,
	  1350051880U,
	  2776293343U,
	  59739276U,
	  1509466529U,
	  159418761U,
	  437718285U,
	  1708834751U,
	  3610371814U,
	  2227585602U,
	  3501746280U,
	  2193834305U,
	  699439513U,
	  1517759789U,
	  504434447U,
	  2076946608U,
	  2835108948U,
	  1842789307U,
	  742004246U
		};

		public static byte get_idx_from_uint(byte idx, uint data) => (byte)(data >> 8 * (int)idx);

		public static uint ainv_mul(uint w)
		{
			return w >> 8 ^ SnowCipher.snow_alphainv_mul[(int)w & (int)byte.MaxValue];
		}

		public static uint a_mul(uint w) => w << 8 ^ SnowCipher.snow_alpha_mul[(int)(w >> 24)];

		private static void snow_loadkey_fast(ECRYPT_ctx ctx, uint IV3, uint IV2, uint IV1, uint IV0)
		{
			ctx.s15 = (uint)ctx.key[3] | (uint)(((int)ctx.key[2] | ((int)ctx.key[1] | (int)ctx.key[0] << 8) << 8) << 8);
			ctx.s14 = (uint)ctx.key[7] | (uint)(((int)ctx.key[6] | ((int)ctx.key[5] | (int)ctx.key[4] << 8) << 8) << 8);
			ctx.s13 = (uint)ctx.key[11] | (uint)(((int)ctx.key[10] | ((int)ctx.key[9] | (int)ctx.key[8] << 8) << 8) << 8);
			ctx.s12 = (uint)ctx.key[15] | (uint)(((int)ctx.key[14] | ((int)ctx.key[13] | (int)ctx.key[12] << 8) << 8) << 8);
			uint num1;
			if (ctx.keysize == 128U)
			{
				ctx.s11 = ~ctx.s15;
				ctx.s10 = ~ctx.s14;
				ctx.s9 = ~ctx.s13;
				ctx.s8 = ~ctx.s12;
				uint s15 = ctx.s15;
				ctx.s6 = ctx.s14;
				ctx.s5 = ctx.s13;
				uint s12 = ctx.s12;
				ctx.s7 = s15;
				ctx.s4 = s12;
				ctx.s3 = ~s15;
				ctx.s2 = ~ctx.s14;
				ctx.s1 = ~ctx.s13;
				num1 = ctx.s12;
			}
			else
			{
				ctx.s11 = (uint)ctx.key[19] | (uint)(((int)ctx.key[18] | ((int)ctx.key[17] | (int)ctx.key[16] << 8) << 8) << 8);
				ctx.s10 = (uint)ctx.key[23] | (uint)(((int)ctx.key[22] | ((int)ctx.key[21] | (int)ctx.key[20] << 8) << 8) << 8);
				ctx.s9 = (uint)ctx.key[27] | (uint)(((int)ctx.key[26] | ((int)ctx.key[25] | (int)ctx.key[24] << 8) << 8) << 8);
				uint num2 = ~ctx.s15;
				ctx.s8 = (uint)ctx.key[31] | (uint)(((int)ctx.key[30] | ((int)ctx.key[29] | (int)ctx.key[28] << 8) << 8) << 8);
				ctx.s7 = num2;
				ctx.s6 = ~ctx.s14;
				ctx.s5 = ~ctx.s13;
				ctx.s4 = ~ctx.s12;
				ctx.s3 = ~ctx.s11;
				ctx.s2 = ~ctx.s10;
				ctx.s1 = ~ctx.s9;
				num1 = ctx.s8;
			}
			uint num3 = 2;
			ctx.s0 = ~num1;
			uint num4 = 0;
			ctx.s15 ^= IV0;
			ctx.s12 ^= IV1;
			uint index1 = ctx.s12;
			ctx.s10 ^= IV2;
			uint index2 = ctx.s10;
			ctx.s9 ^= IV3;
			uint num5 = 0;
			uint index3 = ctx.s9;
			uint num6 = ctx.s0;
			uint index4 = ctx.s14;
			uint index5 = ctx.s13;
			uint index6 = ctx.s7;
			uint index7 = ctx.s6;
			uint index8 = ctx.s5;
			uint index9 = ctx.s4;
			uint index10 = ctx.s11;
			uint index11 = ctx.s8;
			uint index12 = ctx.s2;
			uint index13 = ctx.s1;
			uint s3 = ctx.s3;
			ctx.r1 = 0U;
			ctx.r2 = 0U;
			byte index14 = 0;
			uint index15 = s3;
			uint index16;
			uint num7;
			while (true)
			{
				uint num8 = num4 + ctx.s15;
				uint num9 = num6 << 8 ^ index10 >> 8 ^ SnowCipher.snow_alphainv_mul[(int)(byte)index10] ^ SnowCipher.snow_alpha_mul[(int)(num6 >> 24)];
				uint num10 = num5 + index8;
				uint num11 = num5 ^ num8 ^ index12 ^ num9;
				index16 = num11;
				uint num12 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index14] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint1 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num10;
				uint num13 = SnowCipher.snow_T3[(int)idxFromUint1] ^ num12;
				uint num14 = num13 + index7;
				uint num15 = (uint)((int)num13 ^ (int)num10 + (int)num11 ^ (int)index15 ^ (int)(index1 >> 8) ^ (int)index13 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index1] ^ SnowCipher.snow_alpha_mul[(int)(index13 >> 24)];
				index13 = num15;
				uint num16 = num15;
				uint index17 = (uint)(byte)num10;
				uint num17 = (uint)(byte)(num13 + index7);
				uint num18 = num13 + index7 + num16;
				uint num19 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index17] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint2 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num14;
				uint num20 = SnowCipher.snow_T3[(int)idxFromUint2] ^ num19;
				index12 = (uint)((int)num20 ^ (int)num18 ^ (int)index9 ^ (int)(index5 >> 8) ^ (int)index12 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index5] ^ SnowCipher.snow_alpha_mul[(int)(index12 >> 24)];
				uint index18 = (uint)(byte)num17;
				uint num21 = num20 + index6;
				uint num22 = num20 + index6 + index12;
				uint num23 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index18] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint3 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				uint num24 = SnowCipher.snow_alpha_mul[(int)(index15 >> 24)];
				ctx.r1 = num21;
				uint num25 = SnowCipher.snow_T3[(int)idxFromUint3] ^ num23;
				index15 = (uint)((int)num25 ^ (int)num22 ^ (int)index8 ^ (int)(index4 >> 8) ^ (int)index15 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index4] ^ num24;
				uint index19 = (uint)(byte)num21;
				uint num26 = num25 + index11;
				uint num27 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index19] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint4 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num26;
				uint num28 = SnowCipher.snow_T3[(int)idxFromUint4] ^ num27;
				uint num29 = (uint)((int)num28 ^ (int)num26 + (int)index15 ^ (int)index7 ^ (int)(ctx.s15 >> 8) ^ (int)index9 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)ctx.s15] ^ SnowCipher.snow_alpha_mul[(int)(index9 >> 24)];
				uint num30 = num28 + index3;
				index9 = num29;
				uint num31 = num29;
				uint index20 = (uint)(byte)num26;
				uint num32 = (uint)(byte)(num28 + index3);
				uint num33 = num28 + index3 + num31;
				uint num34 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index20] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint5 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num30;
				uint num35 = SnowCipher.snow_T3[(int)idxFromUint5] ^ num34;
				index8 = (uint)((int)num35 ^ (int)num33 ^ (int)index6 ^ (int)(index16 >> 8) ^ (int)index8 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index16] ^ SnowCipher.snow_alpha_mul[(int)(index8 >> 24)];
				uint index21 = (uint)(byte)num32;
				uint num36 = num35 + index2;
				uint num37 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index21] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint6 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				uint num38 = SnowCipher.snow_alpha_mul[(int)(index7 >> 24)];
				ctx.r1 = num36;
				uint num39 = SnowCipher.snow_T3[(int)idxFromUint6] ^ num37;
				index7 = (uint)((int)num39 ^ (int)num36 + (int)index8 ^ (int)index11 ^ (int)index7 << 8) ^ index13 >> 8 ^ SnowCipher.snow_alphainv_mul[(int)(byte)index13] ^ num38;
				uint index22 = (uint)(byte)num36;
				uint index23 = num39 + index10;
				uint num40 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index22] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint7 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = index23;
				uint num41 = SnowCipher.snow_T3[(int)idxFromUint7] ^ num40;
				uint index24 = num41 + index1;
				index6 = (uint)((int)num41 ^ (int)index23 + (int)index7 ^ (int)index3 ^ (int)(index12 >> 8) ^ (int)index6 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index12] ^ SnowCipher.snow_alpha_mul[(int)(index6 >> 24)];
				uint num42 = SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)(byte)index23] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				ctx.r1 = index24;
				index11 = (uint)((int)num42 ^ (int)index24 + (int)index6 ^ (int)index2 ^ (int)(index15 >> 8) ^ (int)index11 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index15] ^ SnowCipher.snow_alpha_mul[(int)(index11 >> 24)];
				uint num43 = num42 + index5;
				uint num44 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)(byte)index24] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint8 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num43;
				uint num45 = SnowCipher.snow_T3[(int)idxFromUint8] ^ num44;
				uint num46 = (uint)((int)num45 ^ (int)num43 + (int)index11 ^ (int)index10 ^ (int)index3 << 8) ^ index9 >> 8 ^ SnowCipher.snow_alphainv_mul[(int)(byte)index9] ^ SnowCipher.snow_alpha_mul[(int)(index3 >> 24)];
				uint num47 = num45 + index4;
				index3 = num46;
				uint num48 = num46;
				uint index25 = (uint)(byte)num43;
				uint num49 = (uint)(byte)(num45 + index4);
				uint num50 = num45 + index4 + num48;
				uint num51 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index25] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint9 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num47;
				uint num52 = SnowCipher.snow_T3[(int)idxFromUint9] ^ num51;
				index2 = (uint)((int)num52 ^ (int)num50 ^ (int)index1 ^ (int)(index8 >> 8) ^ (int)index2 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index8] ^ SnowCipher.snow_alpha_mul[(int)(index2 >> 24)];
				uint num53 = num52 + ctx.s15;
				uint index26 = (uint)(byte)num49;
				uint num54 = (uint)(byte)(num52 + (uint)(byte)ctx.s15);
				uint num55 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index26] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint10 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				uint num56 = SnowCipher.snow_alpha_mul[(int)(index10 >> 24)];
				ctx.r1 = num53;
				uint num57 = SnowCipher.snow_T3[(int)idxFromUint10] ^ num55;
				index10 = (uint)((int)num57 ^ (int)num53 + (int)index2 ^ (int)index5 ^ (int)(index7 >> 8) ^ (int)index10 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index7] ^ num56;
				uint index27 = (uint)(byte)num54;
				uint num58 = num57 + index16;
				uint num59 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index27] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint11 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num58;
				uint num60 = SnowCipher.snow_T3[(int)idxFromUint11] ^ num59;
				uint num61 = (uint)((int)num60 ^ (int)num58 + (int)index10 ^ (int)index4 ^ (int)(index6 >> 8) ^ (int)index1 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index6] ^ SnowCipher.snow_alpha_mul[(int)(index1 >> 24)];
				uint num62 = num60 + index13;
				index1 = num61;
				uint num63 = num61;
				uint index28 = (uint)(byte)num58;
				uint num64 = (uint)(byte)(num60 + index13);
				uint num65 = num60 + index13 + num63;
				uint num66 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index28] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint12 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num62;
				uint num67 = SnowCipher.snow_T3[(int)idxFromUint12] ^ num66;
				uint num68 = (uint)((int)num67 ^ (int)num65 ^ (int)ctx.s15 ^ (int)(index11 >> 8) ^ (int)index5 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index11] ^ SnowCipher.snow_alpha_mul[(int)(index5 >> 24)];
				uint num69 = num67 + index12;
				index5 = num68;
				uint num70 = num68;
				uint index29 = (uint)(byte)num64;
				uint num71 = (uint)(byte)(num67 + index12);
				uint num72 = num67 + index12 + num70;
				uint num73 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index29] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint13 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num69;
				uint num74 = SnowCipher.snow_T3[(int)idxFromUint13] ^ num73;
				index4 = (uint)((int)index16 ^ (int)num74 ^ (int)num72 ^ (int)(index3 >> 8) ^ (int)index4 << 8) ^ SnowCipher.snow_alphainv_mul[(int)(byte)index3] ^ SnowCipher.snow_alpha_mul[(int)(index4 >> 24)];
				uint index30 = (uint)(byte)num71;
				uint index31 = (uint)(byte)(num74 + index15);
				uint num75 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)index30] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)];
				uint idxFromUint14 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				uint index32 = ctx.s15 >> 24;
				ctx.r1 = num74 + index15;
				uint num76 = SnowCipher.snow_T3[(int)idxFromUint14] ^ num75;
				uint num77 = num76 ^ num74 + index15 + index4;
				num7 = num77;
				uint idxFromUint15 = (uint)SnowCipher.get_idx_from_uint((byte)1, ctx.r1);
				ctx.s15 = (uint)((int)num77 ^ (int)index13 ^ (int)ctx.s15 << 8) ^ index2 >> 8 ^ SnowCipher.snow_alphainv_mul[(int)(byte)index2] ^ SnowCipher.snow_alpha_mul[(int)index32];
				index14 = (byte)(num76 + index9);
				num4 = num76 + index9;
				uint num78 = SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T0[(int)(byte)index31] ^ SnowCipher.snow_T1[(int)idxFromUint15];
				uint idxFromUint16 = (uint)SnowCipher.get_idx_from_uint((byte)3, ctx.r1);
				ctx.r1 = num76 + index9;
				num5 = SnowCipher.snow_T3[(int)idxFromUint16] ^ num78;
				if (--num3 != 0U)
					num6 = index16;
				else
					break;
			}
			ctx.s14 = index4;
			ctx.s13 = index5;
			ctx.s12 = index1;
			ctx.s7 = index6;
			ctx.s6 = index7;
			ctx.s5 = index8;
			ctx.s4 = index9;
			ctx.s11 = index10;
			ctx.s10 = index2;
			ctx.s9 = index3;
			ctx.s8 = index11;
			ctx.dword40 = num7;
			ctx.s0 = index16;
			ctx.s2 = index12;
			ctx.r2 = num5;
			ctx.s1 = index13;
			ctx.s3 = index15;
			ctx.dword44 = num4;
			ctx.keysize = 16U;
		}

		public static void snow_keystream_fast(ECRYPT_ctx ctx, uint[] keystream_block)
		{
			ctx.s0 = SnowCipher.a_mul(ctx.s0) ^ ctx.s2 ^ SnowCipher.ainv_mul(ctx.s11);
			uint num1 = ctx.r2 + ctx.s5;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num1;
			keystream_block[0] = ctx.r1 + ctx.s0 ^ ctx.r2 ^ ctx.s1;
			ctx.s1 = SnowCipher.a_mul(ctx.s1) ^ ctx.s3 ^ SnowCipher.ainv_mul(ctx.s12);
			uint num2 = ctx.r2 + ctx.s6;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num2;
			keystream_block[1] = ctx.r1 + ctx.s1 ^ ctx.r2 ^ ctx.s2;
			ctx.s2 = SnowCipher.a_mul(ctx.s2) ^ ctx.s4 ^ SnowCipher.ainv_mul(ctx.s13);
			uint num3 = ctx.r2 + ctx.s7;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num3;
			keystream_block[2] = ctx.r1 + ctx.s2 ^ ctx.r2 ^ ctx.s3;
			ctx.s3 = SnowCipher.a_mul(ctx.s3) ^ ctx.s5 ^ SnowCipher.ainv_mul(ctx.s14);
			uint num4 = ctx.r2 + ctx.s8;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num4;
			keystream_block[3] = ctx.r1 + ctx.s3 ^ ctx.r2 ^ ctx.s4;
			ctx.s4 = SnowCipher.a_mul(ctx.s4) ^ ctx.s6 ^ SnowCipher.ainv_mul(ctx.s15);
			uint num5 = ctx.r2 + ctx.s9;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num5;
			keystream_block[4] = ctx.r1 + ctx.s4 ^ ctx.r2 ^ ctx.s5;
			ctx.s5 = SnowCipher.a_mul(ctx.s5) ^ ctx.s7 ^ SnowCipher.ainv_mul(ctx.s0);
			uint num6 = ctx.r2 + ctx.s10;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num6;
			keystream_block[5] = ctx.r1 + ctx.s5 ^ ctx.r2 ^ ctx.s6;
			ctx.s6 = SnowCipher.a_mul(ctx.s6) ^ ctx.s8 ^ SnowCipher.ainv_mul(ctx.s1);
			uint num7 = ctx.r2 + ctx.s11;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num7;
			keystream_block[6] = ctx.r1 + ctx.s6 ^ ctx.r2 ^ ctx.s7;
			ctx.s7 = SnowCipher.a_mul(ctx.s7) ^ ctx.s9 ^ SnowCipher.ainv_mul(ctx.s2);
			uint num8 = ctx.r2 + ctx.s12;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num8;
			keystream_block[7] = ctx.r1 + ctx.s7 ^ ctx.r2 ^ ctx.s8;
			ctx.s8 = SnowCipher.a_mul(ctx.s8) ^ ctx.s10 ^ SnowCipher.ainv_mul(ctx.s3);
			uint num9 = ctx.r2 + ctx.s13;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num9;
			keystream_block[8] = ctx.r1 + ctx.s8 ^ ctx.r2 ^ ctx.s9;
			ctx.s9 = SnowCipher.a_mul(ctx.s9) ^ ctx.s11 ^ SnowCipher.ainv_mul(ctx.s4);
			uint num10 = ctx.r2 + ctx.s14;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num10;
			keystream_block[9] = ctx.r1 + ctx.s9 ^ ctx.r2 ^ ctx.s10;
			ctx.s10 = SnowCipher.a_mul(ctx.s10) ^ ctx.s12 ^ SnowCipher.ainv_mul(ctx.s5);
			uint num11 = ctx.r2 + ctx.s15;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num11;
			keystream_block[10] = ctx.r1 + ctx.s10 ^ ctx.r2 ^ ctx.s11;
			ctx.s11 = SnowCipher.a_mul(ctx.s11) ^ ctx.s13 ^ SnowCipher.ainv_mul(ctx.s6);
			uint num12 = ctx.r2 + ctx.s0;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num12;
			keystream_block[11] = ctx.r1 + ctx.s11 ^ ctx.r2 ^ ctx.s12;
			ctx.s12 = SnowCipher.a_mul(ctx.s12) ^ ctx.s14 ^ SnowCipher.ainv_mul(ctx.s7);
			uint num13 = ctx.r2 + ctx.s1;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num13;
			keystream_block[12] = ctx.r1 + ctx.s12 ^ ctx.r2 ^ ctx.s13;
			ctx.s13 = SnowCipher.a_mul(ctx.s13) ^ ctx.s15 ^ SnowCipher.ainv_mul(ctx.s8);
			uint num14 = ctx.r2 + ctx.s2;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num14;
			keystream_block[13] = ctx.r1 + ctx.s13 ^ ctx.r2 ^ ctx.s14;
			ctx.s14 = SnowCipher.a_mul(ctx.s14) ^ ctx.s0 ^ SnowCipher.ainv_mul(ctx.s9);
			uint num15 = ctx.r2 + ctx.s3;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num15;
			keystream_block[14] = ctx.r1 + ctx.s14 ^ ctx.r2 ^ ctx.s15;
			ctx.s15 = SnowCipher.a_mul(ctx.s15) ^ ctx.s1 ^ SnowCipher.ainv_mul(ctx.s10);
			uint num16 = ctx.r2 + ctx.s4;
			ctx.r2 = SnowCipher.snow_T0[(int)SnowCipher.get_idx_from_uint((byte)0, ctx.r1)] ^ SnowCipher.snow_T1[(int)SnowCipher.get_idx_from_uint((byte)1, ctx.r1)] ^ SnowCipher.snow_T2[(int)SnowCipher.get_idx_from_uint((byte)2, ctx.r1)] ^ SnowCipher.snow_T3[(int)SnowCipher.get_idx_from_uint((byte)3, ctx.r1)];
			ctx.r1 = num16;
			keystream_block[15] = ctx.r1 + ctx.s15 ^ ctx.r2 ^ ctx.s0;
		}

		public static void ECRYPT_keysetup(ECRYPT_ctx ctx, sbyte[] key, uint keysize, uint ivsize)
		{
			for (uint index = 0; index < keysize; ++index)
				ctx.key[(int)index] = key[(int)index];
			ctx.keysize = keysize;
		}

		public static void ECRYPT_ivsetup(ECRYPT_ctx ctx, byte[] iv)
		{
			SnowCipher.snow_loadkey_fast(ctx, BitConverter.ToUInt32(iv, 0), BitConverter.ToUInt32(iv, 4), BitConverter.ToUInt32(iv, 8), BitConverter.ToUInt32(iv, 12));
		}

		public static unsafe void ECRYPT_process_bytes(
		  int action,
		  ECRYPT_ctx ctx,
		  byte[] input,
		  byte[] output,
		  uint msglen,
		  uint partLength = 4)
		{
			int num = 0;
			fixed (byte* numPtr1 = input)
			fixed (byte* numPtr2 = output)
			{
				byte* numPtr3 = numPtr1;
				byte* numPtr4 = numPtr2;
				while (msglen >= partLength)
				{
					for (uint index = 0; index < partLength / 4U; ++index)
					{
						*(int*)(numPtr4 + (long)index * 4L) = (int)*(uint*)(numPtr3 + (long)index * 4L) - (int)ctx.getKey();
						num += 4;
					}
					msglen -= partLength;
					numPtr3 += partLength;
					numPtr4 += partLength;
				}
				if (msglen > 0U)
				{
					byte[] bytes = BitConverter.GetBytes(ctx.getKey());
					for (uint index = 0; index < msglen; ++index)
						output[(int)index] = (byte)((uint)input[(int)index] - (uint)bytes[(int)index]);
				}
			}
		}
	}
}

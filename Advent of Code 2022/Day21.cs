using Advent_of_Code_2022.libs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2022
{
    internal class Day21
    {
        //https://adventofcode.com/2022/day/21

        //const string input = "root: pppw + sjmn\r\ndbpl: 5\r\ncczh: sllz + lgvd\r\nzczc: 2\r\nptdq: humn - dvpt\r\ndvpt: 3\r\nlfqf: 4\r\nhumn: 5\r\nljgn: 2\r\nsjmn: drzm * dbpl\r\nsllz: 4\r\npppw: cczh / lfqf\r\nlgvd: ljgn * ptdq\r\ndrzm: hmdt - zczc\r\nhmdt: 32";
        const string input = "nprq: 2\r\nwvzt: 5\r\nmlgg: 2\r\nlnrg: msgc + slpg\r\ndbmv: 5\r\nzpmd: 6\r\nqmvp: llms + rmjj\r\nllsn: 11\r\ndppq: 2\r\nvnqj: 4\r\nlpdz: jznp * rjft\r\npdmh: jscl * plbn\r\nthvd: wzjp / dppq\r\nstpf: 1\r\nbmqc: hjbc - rfmb\r\ndgjc: jzlg * sbzb\r\ngfbb: 5\r\nvrjz: 5\r\nrmgd: 1\r\ntfmm: rhwf * btbr\r\nzhsf: chzv + nwrh\r\nrnwc: hgmm + nrtw\r\nbgsm: glsf + hcwp\r\nvwqd: 4\r\nqvvg: qhcg + stpf\r\ncqpd: bhwg + stwf\r\nwprl: 4\r\ncvzv: lnbg * sstb\r\nqdrz: dfdq * wcjn\r\ndszj: jvfw * rwwz\r\nlfnz: mfvg * vvbm\r\nchzq: mrzl - zjnc\r\nrmhv: zfgv + pqjl\r\nhfsf: wshc / hwrw\r\ntpmw: 17\r\nfzgj: 3\r\njjjr: zdcm - rrbj\r\ndbfh: bcmr + zgrc\r\nhcfd: 4\r\nhjwg: 4\r\nfbbz: qpbw + phpl\r\ngwzj: sngg * nttl\r\njvdc: vbwq * hqfz\r\nthgv: 3\r\nqlgm: jzlr + dqjc\r\npfzr: nqzq - qnlb\r\nlljm: lbft * dtmz\r\nghdb: 5\r\nscss: vvnj - hfsq\r\nzmmp: 3\r\ntgww: 10\r\ncsgb: vwwh + qbhv\r\nvdms: 7\r\nlmfg: 13\r\nnpjd: rdnt * bwwh\r\ncvsl: 2\r\nfjbm: 1\r\ndfzr: 2\r\nwbwz: 5\r\nqstp: 16\r\njzjj: jnlc + zgsq\r\nnzvh: nwdd + hlsq\r\nqpcn: jggg + bttn\r\nnjhv: mvrm * zsmq\r\ngjch: nctt + srbn\r\nlzgm: 12\r\nddmh: 2\r\nqttr: 15\r\njwlc: qfrj * tzgl\r\ncjns: bhqn - rnhm\r\ngcvd: flcm * phzv\r\nvrht: fhph + csqs\r\njcfl: rwcf * hdtt\r\ndvzw: 2\r\nhfps: dncr + mdjs\r\nsbhv: pzsq - dwvp\r\ntfrb: gfwz * pjrt\r\ncwsq: hnln * qbpc\r\nsrbn: llcm + jjth\r\nrfdf: nwvb + cfgs\r\nfvqc: 6\r\njzzq: 1\r\nnfqw: 3\r\nwwzn: 5\r\nrprl: 3\r\nmdvn: 2\r\nvcpv: 2\r\npmqb: vfcv * bgcf\r\npzzf: pvcc * jrvm\r\ndvmd: qtlb * vbwv\r\nbcvw: trmr * hptb\r\nbbsh: hghq + qmrl\r\ncwlg: mghp - wprl\r\ntqrw: zbtl * jhgl\r\nhczn: 2\r\nlvdv: 7\r\nsfvv: 13\r\nvbbm: 5\r\njfrl: 5\r\ntbjj: 3\r\nqqqq: 5\r\nwrdb: 13\r\nbbpv: gbdn * qjpw\r\nccwj: hznc * smfh\r\nwwnf: nmcn + wjqq\r\nhtrq: 3\r\ndpmz: tvvc + tswl\r\nsgql: wdff * scss\r\nvwzb: 2\r\ngdmq: 7\r\nwjfb: fcmm * ghqb\r\njhgl: 7\r\njrzm: nzvh - dzcc\r\nlrph: 3\r\njfwb: 4\r\njzlg: 3\r\nctzp: lvvf * dbbq\r\ncjfh: cjbs + bpsw\r\nngzt: 8\r\nnrrd: vrnh + rcbr\r\npnbf: 13\r\ngsjs: zdnf + qnft\r\nwwzt: 3\r\ngmgs: qqlz + jnjd\r\nrgzt: 8\r\nwbdq: 3\r\ntgsj: wzvv + cnmz\r\ndpwl: 4\r\njbbm: cslc * rjtn\r\nnwrh: vhlm * hpmm\r\njgmj: 4\r\nqwwl: 2\r\nfcfd: ggtd * lnln\r\nshfh: 4\r\nvfnh: fmdq * qctz\r\nrpst: pqmw + hpbz\r\ndrwl: rgzt + tpvg\r\ntcjr: 2\r\ncppz: tscr * dhpq\r\nfmrv: drjj * tftr\r\ncllv: zpbt - cnsw\r\nrjcw: rdhh * zcvz\r\nzrbz: 11\r\ndfhw: 2\r\nbvtf: 11\r\nqmqb: bdht * hbmg\r\nrqrh: 11\r\nfjgs: fhsp * rjqq\r\nnddc: djcd * gvzz\r\nsznc: 2\r\njsft: rrcs / gpjj\r\npswm: rmcj * bndm\r\nfhdh: mgrn * fnqt\r\nltdc: 3\r\nmdtt: fvwh - ptcq\r\nfcpd: 3\r\nhnmz: 3\r\nbhcs: ncnl + jrrg\r\nmnqr: 3\r\npdnf: jbbm / dpbt\r\nhqhr: 16\r\nbrgr: 3\r\nhsqh: 4\r\ndtsp: gcnn * cbbv\r\nhnln: psct / vjsj\r\nvvzw: 2\r\nclgt: 5\r\nldlm: hfps + pvjd\r\nqdmg: vpvz + vsrb\r\nwmbz: 11\r\nfnqt: 2\r\nbjfr: 1\r\ndqjw: 2\r\ndprl: thvw + cmmf\r\ntsmq: wwnf / lqnz\r\ntgdw: 7\r\nsdhs: ddqs + sjvq\r\nmsqm: 2\r\nsfmq: 3\r\nngch: fhdh + zqnm\r\nrpjn: vbwf + tlqn\r\nwttd: hvss * dmpw\r\nstrj: zmzs + vqlc\r\nzrjr: jrzm - dlwj\r\nznbf: dngb * tvgl\r\npbcg: 5\r\nlmgn: 9\r\nzhhd: qdlt * vjct\r\nzvrp: 7\r\npfrp: lnpn + ngnz\r\nnvfl: 2\r\ngzfv: 4\r\nctlr: gqvq * nnjh\r\nmwfb: 2\r\nvfmz: 2\r\nsldq: 4\r\nlvcf: 8\r\ngzpd: 12\r\nlnbg: bmcv + dbjm\r\nwnsl: dhrb + lgsn\r\nmgpp: 8\r\ndsvn: pvtt * zscw\r\njvgp: 2\r\nzdpt: 4\r\nnttl: fgbh + vzzl\r\nzhdc: 3\r\nwdfb: 7\r\nllcm: 1\r\njntg: 3\r\nlnpn: dbtc * mgpp\r\ncdlf: hdns + nsqz\r\nntcb: lcjs + llgf\r\ntdrr: 10\r\nlhfm: 9\r\nqwbp: 4\r\ntgbb: 3\r\nppnz: 3\r\njnfj: wzqw + scpp\r\nfpfc: 3\r\njdcj: 2\r\nmllp: qzhz * dgfm\r\ndbsv: 4\r\ndngb: bldq * pbcg\r\nnnpw: 4\r\nnhvb: gwpt * lmts\r\nmqzg: ljhw + brss\r\nvcfg: nnzl * gwzz\r\nzphl: 1\r\ntmnp: mhnw * lqpd\r\ndrgg: 5\r\nfsll: tcvc + nnfj\r\nqmfl: mflw / bbwc\r\nrtdl: 6\r\ntbzv: gsfv + hbmn\r\nhjlz: 2\r\ndlwm: tggn * pjqs\r\nqpgs: 2\r\nlzvq: dszj + jrdn\r\ndbtp: 2\r\ncmpb: 3\r\nlrmd: flvp + wzfz\r\nqpzb: rtlc * hzdw\r\ntnrc: wcwc + shfh\r\npdhm: 1\r\njzvb: ggmj + mbpn\r\nvdjv: zgvb * qdnl\r\nzfgv: fznv * dhbh\r\ncjll: 18\r\nmwwq: 2\r\nswzv: 5\r\nfwgm: cztz * rgjs\r\njwrt: 3\r\nvdcg: wwfm / qtqp\r\ntncj: 2\r\nfnpz: 3\r\nzsdv: qwwl * bgsm\r\nbrcc: 3\r\nssrg: 5\r\nplvj: 10\r\nwtbn: tcjn + nchh\r\ntmvj: 1\r\nrdmc: zcjz + rnwc\r\nfzqb: zscf / nmhw\r\ngwjq: 3\r\nqfgs: jmvz + lmgn\r\njmqt: qdrz * wmzl\r\nclbz: jzhl * vrht\r\njwqj: 2\r\nbvwd: 13\r\nvpnr: dfzr * zrhr\r\ngmcn: rbsz * lbgm\r\ngzjp: 3\r\nftlc: 5\r\ntcdf: 11\r\nnhgm: lrqt + nlfz\r\nqjzs: 16\r\nlqvj: 2\r\ntjdw: 5\r\nvrvz: zbhb + pbzj\r\ncqrm: rblq * hgnm\r\nvhlm: 2\r\nqjpw: hjwg + ftcz\r\nltnn: 7\r\nmcqr: wvgb * pbcq\r\nzpbt: dcpz + cjcw\r\nwdwc: nvth * bqml\r\nsprb: dlmb * cndq\r\nnzzr: 3\r\nlwpb: 3\r\nhzzz: 2\r\ntwwp: fmmh - ccgr\r\nlpzb: bdjh * rpzz\r\nbhhr: dpbj / nvzq\r\ndgvd: rtzw * fljw\r\nsmvr: 1\r\ncmdd: 2\r\ntcdp: 7\r\nbttn: 4\r\ngfwj: twtq + mjmc\r\ngwpt: bzzw + zpmr\r\ntltd: 7\r\nmdjs: 5\r\ntldp: bzpc + tdln\r\nrwzw: 4\r\nrqmh: cnbn * lnrp\r\nnrgr: 3\r\ncfgs: 13\r\ndqjc: spbs + swnv\r\nvhph: dttr + npcq\r\ndjcs: 3\r\ntltr: 7\r\nclzb: 2\r\nfvhw: 13\r\npsrd: qlgm * vdqf\r\ntdlb: brjh + twtz\r\njpnn: 8\r\nchtj: 3\r\nwdqh: tldp + lzpl\r\nshqt: ttgf + vlpn\r\nmjsn: 16\r\nqfwb: tpvf + cmnd\r\nplcd: mfjg + nlhw\r\nvszj: cdgz * rhll\r\nnwnt: 3\r\nzggm: 11\r\nscqr: nbvc + lhzb\r\nclfq: jtgr - dtrd\r\nztlr: nbfb * tdgs\r\nftdq: 3\r\nlfmd: 4\r\ncwsh: 2\r\nfgdm: scnl * jvrb\r\nvpfq: 3\r\nfzfg: 2\r\nfhpd: 3\r\nrtcn: pszt + fwgm\r\ndtfb: wqcl * grdg\r\nzgrc: gvwt + qfpw\r\npgwl: bmhv * jwhf\r\ngbdd: fcwd + qdhs\r\ndccn: wdfb * rpst\r\nrwcf: wfsd + fmzr\r\nnmwh: 6\r\npcdb: 2\r\nhrpz: ctlr - tpsr\r\nbjcr: ldlm * jsjd\r\nbcmr: nflm + rvhn\r\ngzqv: 13\r\ndbzr: 2\r\nswrb: 6\r\nwhpf: 3\r\nscdj: gzjp * vbwn\r\nqhss: 1\r\nvvqg: lttn + vfpp\r\ntqzj: gqhj - zpdf\r\nfvhf: 4\r\nsqsb: tctg * fzfg\r\ntcvc: rcnd / hpzg\r\ngflz: 8\r\nzhrd: gwjq * vnrb\r\nbndm: 8\r\njhcn: tqzh + qplq\r\ndjzq: 2\r\nbgcs: chtd - pdhm\r\nnfhq: 1\r\ndvrs: 3\r\nnpvh: 2\r\nqnlb: lldz + mzfr\r\njnch: zvqd * wcnl\r\nmhhr: dfhw * jtlm\r\ngcnn: fpfc + svfp\r\nbzsv: ghqn * zvch\r\njljh: vhph * fcbn\r\ndhlb: jhcn + hwgn\r\nhrzf: tcdp * dvtc\r\nvbms: 5\r\ndtlt: 3\r\nvbsz: fjrn * glbt\r\npbht: mwvl * vbrl\r\njpjh: qpjb + zwbt\r\ngtmh: ljhs / jwqj\r\nfpgd: 2\r\nhltj: 5\r\npzsq: 17\r\nvhsw: 8\r\ndpbt: 3\r\nfnsd: hncc * gnct\r\nctwv: tnrc + dwhw\r\nhszg: lwns / ljbc\r\nrdmr: 8\r\nnbvc: 2\r\nprff: gzfv + tqbh\r\nqqtp: 2\r\nllpf: 2\r\nphhf: 9\r\ntlqn: zhmr * rngj\r\nnggd: 3\r\nndls: rlfv - wwzl\r\ngbcm: 2\r\nwdch: jbqs + jgnl\r\njmcc: gpbs + lnst\r\ndtbb: hlpd * wmzq\r\nhggd: vhjh + csgb\r\nqjvf: 5\r\ntcwv: 5\r\nnvbv: fnsd + zwhn\r\ncgmg: zfpm + zwzw\r\nsncq: ddcm - tsjd\r\npbhf: qbpg / bjhl\r\nnvwm: qrlm * ccff\r\nwlmt: 2\r\nccwf: 2\r\nqqds: cjht + vngl\r\nqvbd: lsms * hmfz\r\nzbhb: lmdt + thcm\r\nvthj: szhg * rjcw\r\ncnlm: chrc + gvnj\r\njbqs: 15\r\nhbzc: 1\r\nhsbm: 6\r\nvfsb: tntn * hhwj\r\nlcjs: qdmg + sctv\r\njfdb: 3\r\njqdv: 3\r\nhhnd: hzhj * rfmm\r\nsdvv: pcmc + grrz\r\nzjqc: qpng + qqtw\r\nhznc: 8\r\nfhrp: 13\r\nvhjh: 5\r\nhmfz: 2\r\ntlqz: 3\r\nmpnv: 20\r\nlvvn: bpwm * vzwb\r\nbrmj: tmvj + lffq\r\ndbdm: tsws * nnnt\r\nqqpz: lqsz * qwsv\r\ndmzd: qdmr * ftlc\r\nwcdg: 2\r\ndgvm: 17\r\nrjqq: 2\r\ntzbb: dgnb * plhj\r\ntzsj: 18\r\nnwzn: vtqf + sznc\r\nzldq: ggzw + vcqb\r\ndsqs: phgn * qhnh\r\nvjsl: 7\r\nqtgf: 2\r\ncslc: 7\r\ntswl: 1\r\nqbpg: hvgh * zhrd\r\nztbc: rlqq * tlfr\r\nzjqb: vgdp * zpjh\r\nwdff: 2\r\nbwgw: rnlm - jqdv\r\nnmhz: hzlb + fstj\r\njhlv: fcpd * hpfg\r\nrsmh: fjbm + ppzr\r\njbzw: 5\r\nclhw: 3\r\njcqj: nhcp * qvbn\r\ncnsw: 3\r\nqqtw: rqmh / fgfs\r\nchzv: hsgd * dlrv\r\nllhd: lwqf * ndjr\r\nsbbs: czzp * qgtc\r\nrhhc: jzvb * vsqd\r\nrblq: gwzw * zsdv\r\ndbbq: trdn - vfvp\r\nsbsg: fgfb * gwdm\r\nzwgw: wqqh + qfmj\r\ntspj: 11\r\ntwtz: bmcs * jqfw\r\nhfnp: nmwh + trvn\r\nhzdw: 4\r\nsvwc: 9\r\njmjv: gfcd + jrfg\r\nblcn: nmbh - dsvj\r\nvvnj: 10\r\nnlhw: 5\r\nmppt: gmrc + stzf\r\nzvqm: rftg + lnpd\r\nffhl: jhgg + flcr\r\nrdwq: 2\r\nppwp: 6\r\ndcsf: 1\r\njcqf: 2\r\nmptg: rdhv * hmgq\r\ntdgs: 7\r\nnqbh: vfnc * flmn\r\nmwtw: vlrn * dqjw\r\nwnvb: 9\r\ngcqt: 3\r\nbzfm: tfgl + wnmd\r\nbztd: jqfr * tltr\r\ngcgz: 5\r\nbtbr: dsgd + shjz\r\npdlc: pmpp - hzld\r\nhzhj: 15\r\nmvrm: 2\r\nqrrz: ppmj + cvdg\r\nscnl: 2\r\nngbz: bqzh + jzjj\r\nvgdq: cqjp * rgwm\r\nbrss: vdff + ntcj\r\ngtwt: rddc / mfqn\r\njgfg: ztdl * gtjc\r\ngrdg: 7\r\nhhbc: tlts + zzrs\r\nhcsb: 5\r\nghbg: 1\r\nwbgn: 2\r\nvzbp: 3\r\nfstn: 2\r\nvplv: pbvg * mhwg\r\nfnnd: 3\r\ntggn: 2\r\ndcpz: 8\r\nhsgd: vpgd / vmjm\r\nqmfm: hhtp * lgrf\r\nwgmw: 3\r\nghqb: jnvp / mvrh\r\nhnhg: dmzd * sfpv\r\nsthg: 2\r\nsrgl: 3\r\nsmgj: qczf / jscs\r\nffqm: 5\r\npmtv: 6\r\nvbwq: 5\r\nqdnl: tlgr + gdzb\r\nfvwh: plcd * lqsw\r\nbqcr: mpjj * lvgb\r\nghbd: zpjm + nhvt\r\nzdcm: pppb + clmt\r\nvjsj: 2\r\nfmdq: lhmv + fgmr\r\ndhrb: bdgh + rfdf\r\nflnj: cmpb * tmmq\r\ndbgp: 20\r\nplhh: 2\r\nwwtp: ljjw + gslt\r\nzgcs: vgbp * jbzw\r\npwff: gmtl * gwzr\r\nzmbh: 10\r\ntqmn: bwgw + hpnp\r\nnvzq: 4\r\nhwrv: hnds * smnm\r\nlffq: 5\r\ntgcb: nfwz + ztlr\r\nmpgc: hczn * qmvp\r\nmgzq: bhwh + wlnz\r\nfbrg: 3\r\nnthf: rfqc * jthc\r\nmfjg: 3\r\nvgql: 7\r\nqqhn: jwlc - qdqb\r\ndwvp: 4\r\nfqbv: 2\r\nnhlz: 13\r\nsnjh: 2\r\nhqld: 13\r\nbbwc: 2\r\nsspn: 3\r\nsppq: 1\r\nvvwr: 7\r\ndvcj: fnpt - fsvs\r\nmjmj: 3\r\nhdns: tljl - lsjh\r\nfgfs: 7\r\njfvz: 2\r\ntjwn: 2\r\ntgtb: pnhh * gvrb\r\ndgbh: jhlv / clhw\r\nptql: 3\r\njmvz: 2\r\nmzwc: rsjs + nthf\r\nsqwl: 3\r\ndgww: 2\r\nmtwg: fwnb * nrwb\r\nvfqd: dbfh + ncvt\r\nzlmf: 3\r\nsssl: 11\r\nzvnw: 3\r\nsfgc: zmbh + tfmm\r\nqpwf: wmqt * ffdz\r\nwjjt: gnzs + tnts\r\npjgq: gjsh + jgvq\r\ndwnf: btcj * gjfr\r\nzglm: 2\r\nsrvj: gclh * vjvq\r\nplnd: 2\r\nndpr: wcql / zhdc\r\nhlvb: 5\r\ncjbs: 2\r\npvtt: clbj / hjlz\r\nrcbr: cvmz / ldwz\r\nvfzp: 16\r\nrwbj: 3\r\nqczf: vrbl * twjt\r\ndnvh: qhgd * bnbw\r\ntmqg: hlqn + vvss\r\nzsmq: gjnw + qqhn\r\nvbwv: 9\r\nnfwz: 1\r\ncwtl: snds * vhvz\r\nglbt: 5\r\nnnjh: bcvw + gtwt\r\nglcj: 14\r\nnmcn: hrpz + dwnf\r\nfgfb: 2\r\nvsqd: 2\r\nlgrf: 2\r\nrcdq: qnbg * tbjj\r\nhvbh: 4\r\ndrjb: 15\r\nbndb: 2\r\ntcnw: 18\r\nqccw: nvcl - zmjq\r\nldbj: jfwb + jcls\r\nrffj: 13\r\ngdqz: 3\r\nwmjw: 7\r\nswlr: gcqt * mwfb\r\nvfds: lpzb + pfzr\r\nbnvl: 4\r\ndvwj: gsjs + ghnh\r\ntftr: 3\r\nbcmq: 2\r\njwfs: btbt * qsqp\r\ncntp: 2\r\nvhgt: sppq + gmcn\r\nnqnh: 4\r\nccbp: fqlw + wdch\r\nfwqf: sggw * mhss\r\nnrrp: szhv * gmgl\r\njscl: 2\r\nbgvz: 2\r\ndwdd: 19\r\nfgbh: 2\r\nhstz: hwbd / twcb\r\nrlsw: jsft + nfhq\r\nsggw: fzgj * jwrt\r\njzlr: 5\r\nsbvv: nqdb + ftwh\r\ndjbc: ppnz * dgvm\r\nmfqn: 3\r\nvcqb: hvbh + wqsz\r\ncndq: 2\r\npbrj: 11\r\npcmc: vfsb - hznd\r\nccwb: 2\r\npchz: trtm * swrb\r\ngqvq: pzhr * jzbv\r\nhvss: ngch + brjv\r\nqfrj: 5\r\ncnmp: 3\r\nthvw: zphl + pchz\r\nmlwg: 3\r\nddfr: qqtp + mpnv\r\nrzcv: 2\r\nwzfz: jtrl * rqwr\r\nnlbv: npjd + vwsn\r\ncnbn: jdcf * qzpm\r\nrhwf: 3\r\nszmm: nrcz * tdpc\r\nhrqr: 3\r\nzcjs: 3\r\nhgsr: bwqr / tcwv\r\ngfmp: jmwv * jwbp\r\nmplv: 2\r\ncgvz: 20\r\nbldq: 2\r\nbzww: 3\r\nvpvh: tfht * mfwc\r\nbjgg: 7\r\nbbts: zwjm * jtzf\r\ncmmf: zvrp * dzjf\r\nqrlm: 13\r\nphzv: hstn + zgpj\r\nvtpt: msqm * lpqw\r\nhhqs: 3\r\nrhww: 17\r\nsvhm: 3\r\nblfn: 19\r\nmtgf: 4\r\nttgf: cwsq + mwrp\r\nqtqp: 2\r\ncjzw: dvhs + tfrb\r\nghrc: htvt + wgsm\r\nwwfm: twwp + vvqg\r\nhjbc: ghdm * ftdq\r\nflcr: rwsc + lwwg\r\nmbcj: mggn + stcr\r\ngwrz: frcj * dgvd\r\nfhpv: 4\r\nldsr: sthg * nfpt\r\nrdhq: 2\r\nlzzc: vbbm * dpmt\r\nmfbb: 5\r\njcjl: hpwz * dcvs\r\nnhqw: cgmg + dhlb\r\nsqtj: 2\r\ngdnz: zfvj * cgdv\r\nwmmw: pvhv + sbvv\r\nnqdb: gdnz * bbhs\r\nfgpd: fhpv * bvvq\r\nlldz: 12\r\ntlwp: vdbh + nztm\r\ncmhh: 7\r\nmswd: 2\r\nvwwb: rptr + gvjd\r\npdbp: ztqc + rgfg\r\nmvdd: jljh * tpfh\r\nvdff: mhhr / rmjb\r\nnhzs: 3\r\nbtcj: bjcr * cfzc\r\nnbqv: rzbt * wpmn\r\nnhcp: llzb * wdsb\r\ncmgd: 4\r\nhrvn: 4\r\nbrvj: rsmh + glch\r\nzltj: sbbs * prff\r\nmgcc: 1\r\nfjrn: mhdc * fstn\r\nfqpq: 3\r\nlqtr: dtsp * pvms\r\njsfd: mpmf * zccn\r\nlmvv: 9\r\nbmhv: hsvm - mftj\r\nhcbt: 5\r\nhsrq: lfnz - bgqs\r\nmgtj: 5\r\nzpdf: qzcv * jqnt\r\ndtbn: qvbd + hsbm\r\ndtrd: 1\r\nbmcs: djbc / zlmf\r\nchfp: wmdz + vmsv\r\nqpng: twlw * nzvj\r\nwtvj: 2\r\nlrqt: rghr * cdgb\r\nvqqv: sgql / jvgp\r\nggvm: 2\r\ngvwt: 4\r\nmsnt: 3\r\nrgjs: 3\r\nvlzq: 2\r\njvlq: hhqg * pcvt\r\nbzhz: 4\r\ngvnj: rccn / clmq\r\npgrb: zdpt * hfcj\r\nmhlb: 2\r\nnwcp: 2\r\nbshj: 6\r\nfrmc: 6\r\nbczr: 2\r\nzdzp: 3\r\nbnqs: 10\r\ndcgs: fwzh * cjqr\r\nrrcs: lnnc * tqzl\r\nzcjz: tcnw - mtvn\r\nlhzb: 4\r\nrlfv: 7\r\ngsrf: qcnr + pbwh\r\nrccn: bzfm * gfzd\r\nqnft: 10\r\njwhf: 2\r\nmhdc: lqsh + jbsv\r\ndbjm: pcnf * hnjt\r\nqmbd: tjwn * wdtc\r\nzscf: zzlt + vszj\r\nvjrh: gcgv + rjts\r\ntpcv: mwwq * cmgd\r\nmjmc: 5\r\njlgf: qhcc + djrm\r\nbpmn: mpgc + hqvr\r\nqrcc: 1\r\ngjnw: 3\r\njscs: 4\r\nzhnl: 9\r\nmttz: mtth * ljbd\r\nsctv: zlzq + bbsh\r\nnblm: jszp * hrzf\r\njqnt: rgdv + lmlb\r\nmsdw: 5\r\nqplq: lpzq + mjzd\r\ntjgz: wfsn * jdcj\r\nbgpf: 7\r\nbhnj: fpgd * lzsm\r\ngcbr: tqjg * qrcr\r\nhstn: 5\r\ntwjt: 15\r\njjth: 5\r\njvvb: 11\r\nstqv: zmgh * hcbt\r\nhzld: wjjt + nrrp\r\nwdtc: fzwt + rcdq\r\nwfts: 2\r\nqhcg: 6\r\nczch: psrd * szmm\r\ntdpc: 5\r\nfgsl: qfqp + rsdd\r\ngjqv: vwqd * sprb\r\nljhs: pfrp - fdts\r\nhbnl: 11\r\nqgbg: 2\r\nvpvz: dpmz * dsvn\r\nfpjm: 3\r\ndvtc: 2\r\nhvrw: rlsw * bgfl\r\nbvnz: 3\r\njggg: 7\r\nczzp: vnsw - qpnz\r\nvnsw: dtfp * srgl\r\nbnbr: 7\r\njnjd: stqv * gwzj\r\nbpsw: hcfd + vlzr\r\nnffn: 2\r\nnqsz: pdnf * cscw\r\nrjrh: czsq * snjh\r\nvvss: bnrw + pbwm\r\ncvrr: pvbl * mbfb\r\nzjnc: 3\r\nmfwc: srvj + dbdm\r\nhswd: 2\r\ngzll: 5\r\nvwwh: 7\r\ndlrv: lmzh + bhnj\r\npjqs: hcwz + bppc\r\ncmgj: jqcc - bzsv\r\nhpfg: mjws * bmzj\r\ncvmz: qljr - zwgw\r\ndhbh: 4\r\ndqhd: pcdb * zjqb\r\nfwsc: tqhd + dmtg\r\ndccz: scqr + ltdc\r\ncjht: 1\r\nprsn: qccw + tmnp\r\nvpgd: bgvz * gbdd\r\nrlqv: tqvl + jgmj\r\njwbb: djcs + zgcs\r\nqzpm: 3\r\nhpwz: smmw * mgtj\r\nqdwp: plvj * chmp\r\nndlq: 5\r\nhmld: glcj * jvtq\r\nvcvg: 5\r\nmvrh: 2\r\nqrrt: 5\r\nthfv: 3\r\ncsqs: 4\r\nrqwr: qhss + gscg\r\nndsg: lssl / ffqm\r\nrqlg: vbjt * hntd\r\nwwmz: 2\r\nhjrs: 19\r\nzwhn: ppwp * mwtw\r\nzvqd: 2\r\njdpf: ldbj + tszq\r\nbpnm: trcz - nbcp\r\nvfvp: gpmm - rlqv\r\nwgsm: 5\r\ntljl: bshj * hwlv\r\ntrjr: mprp * gfnm\r\ndcvs: 5\r\nqlhl: 8\r\nldwz: 2\r\nqsqp: dprl + dzcz\r\ndzcz: ffcb * ffcz\r\nbppc: 2\r\nwpwd: twgq * vnmn\r\ntstc: 5\r\ngvqd: jmsp / vvqm\r\ntdhh: 7\r\nllzb: 2\r\nrngj: dqlh * ggrc\r\nwbwl: fzqb * sshz\r\nlqzf: 1\r\ntvgl: 5\r\ndzmr: 7\r\nnbfb: 3\r\nlbgm: 4\r\njdrl: htln * thvn\r\nfhph: wzzs - fbrg\r\nmhvq: 2\r\nspbq: 4\r\npjmp: thfv + vplv\r\nwzjp: htbq * pwff\r\nqvpb: hfsf + nddc\r\ndtfp: 7\r\ntwcb: 2\r\njszp: wtbn / ddmh\r\ncmqs: 2\r\nhtln: 7\r\nzjgs: 3\r\nzqwj: 2\r\nvfpp: sssl * vvzw\r\njqfr: 3\r\nmtps: jcjl + hpwt\r\npnhh: 3\r\nzqgm: lwpb + zrbz\r\nglch: gfwj + zdjv\r\nhhgm: 5\r\nfngj: 10\r\nmgvs: 11\r\ngvsp: 13\r\nmfpd: 4\r\ntmqs: 14\r\nfnzq: 4\r\nntsg: gglw * qthn\r\ntnts: tpcv * zfcv\r\nbnrw: 6\r\nqhnh: rhvg + rggq\r\ngclw: vrjz * tdtn\r\nnczf: lzhz * wnjj\r\nbdgh: 3\r\nstft: 4\r\nhrdc: 5\r\ndhwv: rjmh + qjvf\r\nlsjh: 11\r\nvzcj: lhrf + qvvr\r\nlnrp: 3\r\nmhsz: 3\r\ndcbf: lscv * bvrp\r\njqtp: 3\r\nvstg: 11\r\ntrlq: 3\r\nwrcv: sdhs / ggcv\r\nnvvn: 3\r\nglpc: 4\r\nfcls: 9\r\ncfzc: 9\r\nmzfr: fjzz + zclm\r\ngpdt: 3\r\nvhvz: 3\r\ndfwn: jgll + zmll\r\nnwcs: 4\r\nnpfj: 1\r\ngwzw: 2\r\nrhgj: 3\r\nfwdw: shjg * nggd\r\nsdvh: 2\r\nfhsp: 13\r\nnbcp: 1\r\njtpb: hfzg + bdvl\r\njjgz: vcmv + tgsj\r\nmghp: tjdw * bjgg\r\ncdqb: 2\r\nbhwg: hqrf + vstg\r\nhwlv: 11\r\nfjzz: 13\r\nbqzh: hzlr / mtfp\r\nqgmm: tcmv + wmcf\r\ndzcc: wmmw * qgtt\r\nvmsv: mtld * pfjr\r\ngtgs: cdrp * vfmz\r\ntlgr: 12\r\nzwdj: lzgm * nvvn\r\nrggq: jmjv / brmj\r\ntlfr: 8\r\nmpjj: tnrd * mggd\r\nhhtp: 5\r\nhcfj: nqbh - pngr\r\nssml: ggjj + gwbd\r\ngscg: cjll / fdms\r\nhnjt: sncq + wfgr\r\ntrtm: 2\r\nnshm: 1\r\nrpwl: znbf - mbvm\r\nbwqr: pfcd * vzcj\r\ndmtg: vqqv * cvgh\r\nvbrl: hrvn + fvhw\r\ntqss: fvht + djzl\r\nnfcr: rqlg * dtlz\r\njnvp: wbwl + ldgj\r\nrvlt: 7\r\ndfhh: npfj + cvfn\r\ntcdn: nbth * pbrj\r\nczsq: 3\r\nwhvg: wwtp * tmqg\r\nllpb: 19\r\nvtqf: lfcf + qgzf\r\nszhv: 3\r\ncscw: rgvw + qlvv\r\njrwt: rpsg + wqst\r\nshjg: 2\r\ntqhd: fcfd + wlnf\r\ncfrn: 3\r\nwqcl: 2\r\ntpvf: 6\r\nzfcv: ppqz * zwsf\r\nclbj: jvgr * wbgn\r\ngwsj: 8\r\ngmtl: 7\r\nlmts: 2\r\nmmgr: 2\r\nzmhf: vrvz + bvnb\r\nsqdq: 2\r\nwltg: drwl / wfnj\r\nhwzz: 7\r\nchmp: wvcs * mgfc\r\nbhbr: ghdb * jpsq\r\nrrts: dtbn / mtgf\r\nlctc: tqzj / lmvv\r\nnvcl: brzp / bzhz\r\nzmtj: 2\r\ntvzn: lwtv / jnlt\r\nqrpf: 3\r\nmflw: gmgs + zdvc\r\nzlqs: 3\r\nqwsv: rtbv + scdj\r\ngwzr: 2\r\nhgnm: 2\r\nsbtg: mflr * tpmw\r\ngjsh: qnhl + vnqj\r\nmcqz: dvdp - fntw\r\nqbqz: 3\r\npvms: 4\r\nqthn: wrdj + mmtl\r\njcgg: 6\r\njpfd: 4\r\nghqn: tnhl + vnst\r\nsmmw: msdw + tpfr\r\ntgld: 2\r\njnvl: 2\r\nzpjh: 3\r\ntsjd: fmrv - pgsq\r\nflvp: mztm * qgbg\r\npmzp: 5\r\ncdgz: 5\r\nvfnr: wrcp * zslc\r\nfstj: zfld * mdvn\r\ntgdn: tlqz * lnvr\r\nhznd: qljh * bzww\r\nvgbp: lpfw * vcls\r\nftcz: 3\r\njtrf: 1\r\nqnhl: hfql * dnsf\r\njwtf: fwnr / nbpr\r\nddcm: mlrh * hbfm\r\nqcpp: 3\r\njbgh: 3\r\nzqwc: bnvl + rhgj\r\ntsws: nblm + jbgh\r\ngdvz: rdvh * ccbp\r\nlnln: 6\r\nclrg: nshg + cvrr\r\nptqs: 2\r\nbhwh: fltm / vjvv\r\nnlfz: tzbb - dccn\r\npmjb: bsrc * vmgc\r\njllw: 3\r\njwbp: 5\r\nmgrn: nvwm + qmll\r\npjhm: vpfq * hfsj\r\nnnnt: 4\r\njhmw: pdmh / mmgr\r\nbzqq: 4\r\nflmn: 4\r\nzccn: dcsf + jcgg\r\nlwqf: 6\r\nwmqn: bsdn * hqjq\r\nbnjf: 7\r\ntrvn: 5\r\nsbsp: 15\r\nmpvn: 6\r\njdcf: pzws + swvc\r\ntpfh: lctc + mtps\r\nhpjc: 2\r\nbnng: 3\r\ndswq: qmdf - nwcp\r\nrsdd: 7\r\nsdcf: mplv * qcpp\r\nqpcm: 5\r\nrdvh: tgww + rprl\r\nrmjb: 2\r\nmggd: 3\r\nbfvr: 1\r\nlqsh: 12\r\ntlts: gdmq * nzfp\r\njnlc: zjtb * rmhv\r\nhhqg: 9\r\ntlfd: wsmp * zqwc\r\nmhjj: wmms - rdmr\r\nvbpn: tnfb + fgpd\r\nrdhh: 5\r\ngqfr: 5\r\njqcc: bjjb * qncq\r\nfvfw: 3\r\nscmg: fgsl * brgr\r\njthc: 4\r\nvjct: msth * shgn\r\npvjd: 2\r\nzfvj: 2\r\nlzpl: rwls * tgld\r\nmbvm: 9\r\ncqjv: bscm * hjrf\r\nbnbw: 3\r\nqhsj: 2\r\ndmpw: 2\r\nrtzw: 4\r\nblwm: qwjc + vwwb\r\nqctz: 2\r\nvlzr: hzzz * wwzt\r\nrvhn: whmj + vbsz\r\nzrjv: zvhm * hqld\r\nfqlw: 14\r\nqjgw: gvqd * hrqr\r\nlftp: 3\r\nhpmm: bvnz * vfds\r\nwstq: nrwm / jlph\r\nbdjh: 19\r\nrfmm: 3\r\nvlrn: jcgw - znmp\r\nnctt: 5\r\npjrt: 2\r\nhzbc: 5\r\nbrzp: blrp + pzzc\r\ngqzn: 2\r\nhlhs: fnbj * hmcr\r\nwnqq: rpjg + jzwf\r\npvbl: 5\r\nwnjj: 3\r\nrgsm: pjgg + rqln\r\ntszq: 2\r\ntpsr: nvbv * wgmw\r\nfrfc: mjsn * qrrt\r\nzhmr: 3\r\ntnfb: pmjb + hbzc\r\nbvbc: 5\r\njdff: 14\r\njscf: bcbm * rvlt\r\nncrn: 2\r\nplpq: 4\r\nndpz: 3\r\ncgfg: qgmm - nsft\r\nqftb: 3\r\nfhdd: 15\r\njsjd: 3\r\nlnbl: tttg + tqrw\r\nwdqs: 4\r\ntdtn: 5\r\nwmms: dfwn - gzll\r\ndgvz: tdlb * dbzr\r\nmlrh: hstz * nffn\r\nrmjj: 7\r\ngfcd: mfzd * wvqs\r\nprfv: 2\r\ngtjc: sdmj - wmvl\r\ngfzd: 5\r\nvvgw: 17\r\nbvvq: ptql * qtgf\r\ngcsw: lnrg + nrgr\r\nrlfn: 2\r\ndhhj: 3\r\ndpbj: jwfs - zhhd\r\nlzhz: 3\r\nnbqj: 2\r\nppzr: 5\r\ndjcd: 4\r\nnbth: 2\r\nqmrl: qrqj * bbts\r\nhlqn: 2\r\nhwgn: sjrp * nrrd\r\nrfqc: sfvv * wszw\r\nggmj: 12\r\njtzf: 3\r\nfwzh: zplg * rbpw\r\njgll: mtjr * gdqz\r\ncvgh: 2\r\nmhss: 2\r\nrlqq: 4\r\nqdqb: sgzb * nnpw\r\nnqqn: 3\r\nrnlm: 17\r\nwqst: dbtp * gqzs\r\ncfwf: 2\r\nbgfl: 5\r\nzzcz: 2\r\nvngl: dtlt * fqbv\r\njghr: 2\r\ncljd: mhsz * bztd\r\nthrv: 2\r\nstcr: 4\r\nmcvb: qmbd * jdsq\r\nnddl: gcsw * zpcw\r\nbvnb: vdjv / pmzp\r\njlzl: 2\r\nmgfc: 13\r\nzhbv: ntzf + rtdl\r\nvsrb: ghbd * zdzp\r\nbwtt: 2\r\nbsdn: zhnl + zqgm\r\nsjvq: bshr * jqnh\r\nrptr: chzq + fdgl\r\nrpsg: qfwb + nlgs\r\nhbfm: mgng + vtpt\r\nnvth: 2\r\nstzf: 5\r\nthcm: 1\r\ncgdv: 4\r\nbzpc: 4\r\nbbrt: 5\r\nrdhv: dvcj + bnng\r\nqgtt: trft + wwzn\r\nvjbp: vfzp + lljm\r\nvbvt: 2\r\nhfsj: 17\r\nzpjm: gndf * vjsl\r\nmtfp: 5\r\nwrbp: 20\r\ncrhq: tgcb + smvr\r\nqcnr: blwm - pbhf\r\nnrcz: 13\r\nhsvm: zcjs * ssrg\r\npnqh: 4\r\nvqlc: 3\r\ngwdm: bgrs + cnqm\r\ngvrb: ldsr / lqvj\r\nmlwc: qqqq * ggvm\r\nnzfp: 3\r\njcsh: 2\r\nlrtf: 1\r\nrsmr: 5\r\nzvhm: 2\r\nllrs: 2\r\ngrgj: 3\r\njrrg: jghr * tvzn\r\njdmz: 3\r\nghdm: hcsb + dfhh\r\nwmdz: bvjw * sgrq\r\nbpwm: 8\r\ngvzz: 15\r\ncfcp: 17\r\nhmcw: nwzn * wljz\r\nhqmq: 19\r\nmbfb: rqrh * nqnh\r\ntrcz: jzvd + cslh\r\nzdss: 2\r\ntwtq: 2\r\nrcnd: lmhv * sdvh\r\nbfvw: dhjl * vqnw\r\nglsf: drjb + jzzq\r\nlgsn: tmtd * zjgs\r\nvdrd: 12\r\ngjfr: gcgp * pngb\r\nqhgd: pmrj / hdbv\r\ngwbd: gsrf / hpjc\r\nwffq: 6\r\nlmzh: jmvf + rdhq\r\nqlvv: plpq * mrmb\r\ntqjg: 2\r\njdsq: 9\r\nfbgh: 12\r\ntrzv: llpz * lbwn\r\ntncb: 2\r\nqmdf: 9\r\ncmnd: 1\r\nhrcl: 3\r\ntbsz: wmbz + zqwj\r\nnsqz: vgdq * hcfp\r\nvbwf: fwsc + dgvz\r\nqrcr: htrq + fngj\r\nrqln: tqpm * trlq\r\npsvp: jtrf + sbjl\r\nzmgh: sqsb + bnld\r\nzgvb: 3\r\nnszb: stth - lqsg\r\nsshz: rftq + mhvq\r\nwwbb: srwb + nfcr\r\nlsms: 17\r\nsrjl: 3\r\nvzzl: 5\r\nzwjm: 3\r\nwshc: qdhd * dddt\r\njzhl: 4\r\nhqvr: jmgv / lwtw\r\njmvf: 5\r\nfwnr: pdlc + lbqw\r\nzmtf: nzfm * clgt\r\nfrwd: dlwm + gjtw\r\nlqnz: 6\r\nhpzg: 2\r\ndwgs: 5\r\nrwwz: hgpn + rpfb\r\nqqlz: lfsz * lsds\r\nspbs: gqzn * vhsw\r\nrrjv: fhpd * jzql\r\nqgdh: 3\r\nbzzw: wlfc * zmtj\r\nhqjq: 2\r\ngcgv: bpnm * vcpw\r\nmwrp: dpjw * bvtf\r\nvjvq: mppt + qgdh\r\nqzhz: 3\r\nbrjh: 4\r\npdnn: 13\r\ntpsq: sbsg * jjjr\r\nnlfb: 2\r\ndbps: scmg * pgwl\r\nfgmr: vfrw * fvqc\r\nbvjw: 5\r\nhwbd: 14\r\nwwzl: 1\r\nnnzl: 2\r\ngjtw: fhdd * cvsl\r\ntqbh: 7\r\nbshr: 7\r\ntflh: 1\r\nlnst: vlzq * vvjl\r\nhzlr: qpzb - wcqf\r\nbjjb: 2\r\nqvql: qwrj * ngbz\r\ndsgd: 4\r\nfcmm: hqmq + lnzc\r\nwfsn: fnnd * mswd\r\nbnwq: vdhc * chtj\r\nfsvs: 3\r\ntnhl: cppz + bfvr\r\nlntb: zlnl - wstq\r\ngdzb: wrbp + svhm\r\nvnst: qwbp + zggm\r\nwmzl: qvvg * whqg\r\ntdln: 3\r\nfrcj: tzsj / ccwb\r\nmhwg: cfrn * srjl\r\ngqtm: 2\r\ncjnz: zhwl + wlbz\r\nfszt: 4\r\nbnld: 1\r\nffcb: 2\r\nwwnb: 3\r\nsmfb: 2\r\ntqpm: plhh * wbdq\r\nhmcr: 3\r\nfmmh: tqmn / sqtj\r\ngvjd: bhcs + fbqr\r\nmftw: dllq + svrs\r\nmwpd: lzvq / wbwz\r\nrnvj: 5\r\nfgdr: 7\r\nzcvz: zwbb + qzmv\r\nzgpj: 1\r\nlrnm: 3\r\nhmmm: mlwg * zbbp\r\nlqbg: jsth * jnvl\r\nrgwm: 3\r\nzfmp: 4\r\ndfdq: 2\r\nwcwc: wgfj + lpdz\r\ndppg: cntp * gbmj\r\nshgn: 2\r\nqfqp: 2\r\nfcwd: 14\r\njznp: 8\r\nnzfm: 5\r\nzzsg: 2\r\nzscw: 5\r\nrsjs: 5\r\nhwrw: 2\r\nwjrp: 2\r\ntdvz: hwqw - tgdn\r\nnchh: 1\r\ndhjl: vmcz + dnzj\r\npmpp: gssj * jjgz\r\nvhnp: 1\r\njsth: hrcl + tdrr\r\nrhsn: zphd * gpdt\r\ncmts: wzwt + qmqb\r\nnffw: qpwf - fgdm\r\ndtmz: 5\r\njmsp: qhnb / qlhl\r\nvnrb: 2\r\ncjcw: 5\r\nqpjb: gcgz * trzv\r\ntghf: 9\r\njjgg: pwpz * wrdb\r\nmjws: gfbb + ngsz\r\nzslc: llpb * lrlz\r\nfbwp: ccwf * psrm\r\nndjr: hqhr + gbzw\r\nnrwm: ctzp + vdgn\r\nnsft: rwbj * gwfz\r\ntmmq: 5\r\nmrjg: 2\r\nshjz: 3\r\nlqsg: 5\r\nhmhl: 2\r\nwfnj: 2\r\npzhr: 4\r\ndrjj: cfqj - fwzj\r\nrjft: 4\r\nwszw: 2\r\nrghr: 13\r\nvpgq: rvcc + wdcl\r\nffdz: 2\r\nroot: qmfl + qdpj\r\ngmrc: 2\r\nsstb: 2\r\nvpnv: 3\r\nbgqr: sspn * lrph\r\nvtqm: 2\r\nqrrv: 4\r\ntqzh: tczc * zpmd\r\nmprp: gwsj + clrg\r\nwfsd: 4\r\npjgg: 1\r\nllpz: tjgz + vhnp\r\nbqml: rhqh * dvzw\r\nbgcf: 3\r\nrdnt: 5\r\nsjrp: 6\r\nwvqs: 5\r\njvgr: ndlq + gjqv\r\nmtld: wlmt + rrts\r\ntpfr: 14\r\nbjhl: 2\r\njhqj: mgzg + ghbg\r\njrdn: wdwc * nszb\r\ndncr: 2\r\nsrwb: twpb * cnmp\r\nllms: 12\r\ndwhw: gflz * zzsq\r\nmlpm: ntsg + vpvh\r\nrddc: rnrn / tncb\r\nwlnz: gbcm * drgg\r\ngsfv: zrjv / zzsg\r\nlfsz: zmtf + mgcc\r\nqbbp: 7\r\nqgnv: zgfw * wnsl\r\nfnpt: psjz - tghf\r\nntcj: 3\r\njmgv: fvts + rgsm\r\nrbsz: 3\r\nrnhm: 3\r\ngclh: jqtp + fjgs\r\ngpbs: 5\r\ncdgb: nbqv + pdnn\r\nvgrw: 1\r\ncrdz: 1\r\nvmgc: 2\r\npbwm: 5\r\nfwnb: 3\r\nfmrc: bqcr - ffmz\r\npzzc: dhhj * vpnr\r\nwlnf: 8\r\nsmnm: nvfl * jntg\r\nwlfc: cllv - bbjg\r\nngfl: mvdd - ntvr\r\nftwh: 5\r\ndjtq: prfv * mgzq\r\nbvzd: 2\r\nhbmn: tjlg * mqcr\r\nlvgb: 3\r\njvbn: fvnh + vfnr\r\nwdsb: dcgs + sdvv\r\nvrbl: 8\r\nrpjg: ssml * dcbf\r\nphpl: 1\r\nggjw: ngzt * jmzz\r\nqbpc: 2\r\nqfpw: wjrp * msqp\r\nqrqj: 3\r\nnvlg: sgnr * rlfn\r\npvhv: jpfd * zgsd\r\nwcql: vbpn * gfqw\r\ntpvg: 14\r\ntqvl: qjnb + szmh\r\nstwj: 14\r\nqpbw: sqwl * cwsh\r\nhsgz: 3\r\ntwpb: 3\r\nlzqp: qrpf * jdmz\r\ncgtt: dmjh + nqsz\r\nzgrl: 1\r\nlttn: 9\r\npfcd: 5\r\nrbds: 8\r\nffmz: 5\r\nqdhs: 17\r\npcnf: 3\r\nwnmd: 2\r\nnwvb: dtsm + bgcs\r\nwzzs: mvbb + bstc\r\nflvl: sbdv * wwmz\r\nzgfw: ctth * vdms\r\ndvpj: wftp * rljr\r\nmgzg: 5\r\nzzsq: 4\r\nbwwh: 5\r\nhpwt: frfc + bpfl\r\nhdtt: 3\r\nplhj: bhhr + zldq\r\nzlzq: rrjs * bbwr\r\nsgrq: 11\r\ndsvj: dplh + mcvb\r\nlzgd: bjdz + tgbb\r\nsbjl: 10\r\ndvhs: 1\r\nwqqh: 7\r\nqzmv: 5\r\ncsrl: 19\r\nglzv: nhvb + ttjz\r\nbdht: 18\r\npwpz: llsn * jlgf\r\nzwzw: mnwt * sbsp\r\nrjtn: gbsg * vznp\r\nzzrs: 10\r\nwzvv: djtq + rmdp\r\nsgnr: glzv - tcdf\r\npmbz: mhjj + tdvz\r\ndtsm: 11\r\nbbjg: 3\r\ngnzs: whvg + stlh\r\nljjw: dwgs + fqpq\r\nrnrn: nvlg * gtmh\r\nswnv: htdh * rwzw\r\nsgzb: 2\r\ntctg: 3\r\nwqqr: 2\r\ncslh: vbvt + hrdc\r\ndsgc: 8\r\nqvbn: 2\r\ngmgl: 8\r\nsqzg: gjch * tsmq\r\nqjnd: 3\r\nlnpd: mllp * czch\r\ntqgq: fmrc * hcfj\r\nrfjb: 6\r\nhbnc: swzv * jrrd\r\nzmjq: wpjf + zrjr\r\nnbpr: cdqb + srzw\r\nzzlt: jdpf * dccz\r\nrgvw: 5\r\njtlm: dvmd + mhlb\r\nwljz: 2\r\nngnz: wfts * flnj\r\nlwtw: 2\r\ngcgp: lvdv * rffj\r\nzfld: tdwg / hbsl\r\nntcf: bjfr + bffs\r\nrnfj: 8\r\ncjzd: fmmd * ggjw\r\nfljw: 2\r\nwlsq: dtfb * qbqz\r\nhwqw: wdqh * jfdb\r\nslpg: 7\r\nhtvt: 3\r\ngfqw: 3\r\ncwrn: chfp / hltj\r\nsfpv: pzzf + qbbp\r\nzsrb: 2\r\nbbwr: mzwc * wmjw\r\njrzr: 3\r\nchtd: 18\r\njvfw: rdmc - dvlz\r\nswvc: 5\r\nlcgn: bdgd / snvf\r\njmzz: 2\r\nbstc: 3\r\nqbhv: sdcf + hhdn\r\nldgj: qrrz * bpmn\r\nfnwz: 3\r\nrjts: 18\r\nfbqr: fbbz * jdrl\r\ndvlz: 2\r\nmvbb: 19\r\njbwj: 2\r\nvcpw: 2\r\nlcjw: 3\r\nljbc: 2\r\ngslz: tgtb / fnpz\r\nbwrp: 5\r\ngslt: 15\r\nmjzd: vhnl + jdff\r\nfslb: 1\r\ntddz: rnfj + rhsn\r\nsmfh: 2\r\nljhw: jchg + gpnj\r\nggrc: 3\r\nnjjd: cfcp + wnvb\r\njpsq: 4\r\nfvnh: vthj / pbgp\r\nhjrf: 3\r\ndhpq: 3\r\nhlpd: 3\r\njnmz: 15\r\ntrdn: vpgq / zvnw\r\ntjlg: njhv + dgbh\r\npgmp: 2\r\nlrvc: dhwv + prtq\r\nvvjl: 3\r\nqzcv: cjzd - bnwq\r\nhntd: 3\r\nptcq: bmqc + cjnz\r\ncqjp: 9\r\nczsr: 2\r\nmrmb: 2\r\njbsv: nbqj * tstc\r\ndlmb: 3\r\nqtlb: 3\r\nlnzc: 7\r\nhcwp: 3\r\nwcnl: 7\r\nrtbv: cqpd - lftp\r\ntqzl: 4\r\njgnl: 2\r\ndgsq: jsrr - wwnb\r\njcls: 4\r\nvznp: 6\r\nstlh: mgvs * tcdn\r\nnptd: 3\r\nwrzd: thtw + zwlf\r\nmfvg: 3\r\npgsq: 4\r\nbpfl: swlr * qttr\r\nrgfg: 9\r\njmtd: 2\r\nsbdv: 12\r\nrjmh: 18\r\nrhvg: 5\r\ndddt: 2\r\nqjnb: 1\r\nffcz: wfrm - wfpv\r\nlqpd: qstp * mrjg\r\nwfpv: czbq * vdcg\r\nppmj: wwbb * frmc\r\nzwbt: mqzg + dgjc\r\nqwrj: 4\r\ngwfz: fvhf * qpgs\r\ntfht: phzl + ptpg\r\nnwdd: mwpd * qnjm\r\nwhqg: 2\r\nlqgv: nnpn * lnbl\r\nfwzj: 2\r\ntrft: 2\r\nhbmg: 7\r\nlnnc: lrnm + jnch\r\ntmtd: 5\r\nnrwb: 3\r\nbgqs: 4\r\ncvdg: bbrt * jrbl\r\nhfsq: 3\r\nwhnc: stwj * rdwq\r\nthvn: wlsq / fwdw\r\nncvt: qfgs * qjgw\r\nmccs: vvwr * lzqp\r\nmtjr: 3\r\nwpmj: glpc + hhqs\r\nsvfp: 4\r\ngglw: 2\r\nqdlt: 2\r\nrvcc: nffw * zsrb\r\nvbjt: 7\r\nmnwt: 3\r\nfwpb: 7\r\nzpcw: 3\r\ngpjj: 2\r\nzlnl: zvqm * jjgg\r\ngrzq: 5\r\nfbmh: 18\r\nnztm: 18\r\nbdvl: 5\r\nmzgc: mccs * pnbf\r\nzmll: wvzt * hlvb\r\njzwf: sqzg * mnqr\r\nfsld: mvzb * rpjn\r\nvfdn: 5\r\nmbfj: dvwj + mftw\r\nzwlf: hnhg * cnhn\r\nqljr: nhgm / sqdq\r\nnmbh: nhqw / vdgc\r\npszt: 14\r\nvjvv: 5\r\npsjz: tddz + fwqf\r\ndllq: 2\r\nwftp: 3\r\nbzss: ccsj * fpjm\r\nblrp: cmgj * pgmp\r\ndqmq: 4\r\nrcmt: cwtl * shqt\r\nrfmb: 8\r\ngqhj: mdtt / rsmr\r\nmrzl: vgql + dpzn\r\nlmdt: 19\r\nvvbm: svrc + cfwf\r\ndnsf: 5\r\ngnct: 5\r\nccgr: glgp * jfrl\r\njcgw: 14\r\nmvzb: 2\r\nqpnz: 4\r\nhfzg: lqzf + fhrp\r\ncnrt: 2\r\npbcq: sncj - fslb\r\nhtdh: 2\r\nhbsl: 3\r\nzpqh: 8\r\nvhvn: fsld + qvql\r\ndzjf: 15\r\njvnj: gzqv * mbcj\r\njhnc: 2\r\nsngg: 2\r\nrmdp: lzzc * jbwj\r\nrhll: dbgp + nzzr\r\nsvrc: 5\r\nbscm: 3\r\nvcls: 2\r\ncnqm: 8\r\nnnfj: clbz * wdqs\r\nsdmj: bvzd * hsrq\r\nvcmv: ngfl / qpcn\r\nbmzj: 7\r\nfgqh: 2\r\nmzcv: dpwl * blcn\r\nsmqn: 3\r\nzhwl: cgrn + qwsr\r\npppb: 10\r\ndlwj: cgvz * btsd\r\ncfqj: hfnp + hswd\r\nbgrs: 5\r\ngndf: 3\r\nwvcs: 2\r\nrtlc: jwtf + tbzv\r\ncnmz: hmcw * rbbm\r\nltmj: 3\r\ngbdn: thvd - pbdd\r\nttjz: 16\r\nmmtl: rcmt + cgfg\r\nmbfg: thgv * brvj\r\nclmt: nlrm + lhfm\r\nvnmn: vjrh + nddl\r\ncwjz: rjrh + pgrb\r\nbtsd: 9\r\npbgp: 4\r\njzql: 3\r\nntvr: qgnv / vcvg\r\npcvt: jnfj * bcmq\r\nlcjl: wcvg + svwc\r\nczbq: 10\r\ngbzw: qqds * whpf\r\nhvgh: qmfc + qjzs\r\ntmnh: rnvj * cmqs\r\nsncj: jcqf * sldq\r\nhqfz: 5\r\nftrz: 4\r\nqgzf: 5\r\nlvvf: 3\r\nghnh: fvfw * fbmh\r\nvvqm: 2\r\nnqzq: sbtg - cwrn\r\nrzbt: dctc * nlfb\r\nggzw: zmhf + pjhm\r\nwfrm: vhvn / zdss\r\nfdms: 3\r\nlgtr: 2\r\nngsz: 2\r\ncbls: 3\r\nfdgl: gcvd + vvgw\r\nhplz: jvnj + hhnd\r\nwzwt: zwdj + ndls\r\njzvd: 5\r\ntntn: 11\r\ncfpv: tgdw + lcjw\r\nljbd: fcls + plnd\r\nvgnt: 5\r\npqjl: hjrs * tdhh\r\nwtsp: qhsj * vzbp\r\ntcjn: jpnn + vgnt\r\nvdgc: 3\r\ndrwm: 4\r\nzmzs: jvvb * jlzl\r\nbcbm: 2\r\njhgg: njjd - qpgj\r\nprtq: pnqh * pbht\r\ngpnj: mpvn * jhnc\r\ncbbv: 2\r\nfpnq: 13\r\nzvch: hwzz + lzgd\r\nqgtc: hbnl + hfst\r\ndjrm: ftrz * vfdn\r\nhhdn: 5\r\nfntw: 10\r\nnmhw: 5\r\ndgnb: 2\r\nzdjv: 6\r\nrmcj: qpcm + pmtv\r\nlrlz: 2\r\nrgdv: czsr * zfmp\r\nqhcc: ghrc + brcc\r\nlscv: 14\r\nhmgq: 3\r\nrjgc: 2\r\nwmqt: wrcv + tgrs\r\ndtlz: 2\r\nqnjm: 2\r\ntjzz: gtgs * fpnq\r\nqdhd: clfq + fqtl\r\nplbn: ghzz + gzhl\r\ndctc: qqtc + lrtf\r\nfltm: zmmp * jrwt\r\nlssl: jcsh * ntqg\r\ndjzl: wffq * lbhn\r\nvmcz: 6\r\njtrl: 5\r\nzphd: 2\r\nhqrf: 19\r\nwmzq: 4\r\nthtw: zltj * phqm\r\nhgpn: 3\r\nwlbz: dsqs + csrl\r\nzjtb: 3\r\nrwsc: 9\r\nvdqf: 7\r\nnjht: wcdg + grzq\r\nmgng: fszt * zzcz\r\npgwf: 2\r\ntwgq: 9\r\nlbwn: 3\r\nqmll: 7\r\njlph: 2\r\njchg: 7\r\nwsmp: 16\r\nhumn: 335\r\nlsds: 9\r\nmsgc: 13\r\nwpmn: 2\r\nggjj: tngv * rhww\r\nrftq: dnvh * nhlz\r\nnzvj: 2\r\nnnpn: 2\r\nzbbp: cqjv - bndb\r\ndpzn: dppg * bgqr\r\nzbtl: 4\r\nvdbh: smqn * lbqn\r\ntwlw: 5\r\nqncq: hszg - nhvj\r\nbrjv: ndsg + dtbb\r\nghzz: tlfd + ndpr\r\nmwvl: 3\r\nqnbg: 8\r\nvlpn: gqtm * whnc\r\nzclm: nprq * rbds\r\nsvrs: 4\r\nwqsz: tbsz * wqqr\r\nwgfj: 3\r\nvgdp: msjw + stft\r\nhnds: 11\r\nbdgd: wrzd * cnvp\r\nnzhm: pmbz / lnzw\r\nfhqz: 2\r\nglgp: 2\r\nfcbn: 5\r\nqwjc: crhq * sbhv\r\nlwtv: jpzh - frwd\r\nvzwb: 8\r\nmsqp: mttz + qqpz\r\nlhmv: 5\r\nzdnf: 1\r\nvfnc: 2\r\nppqz: 2\r\nhdbv: 2\r\ndpjw: rjgc + qgff\r\nrpzz: 2\r\ngwzz: 4\r\ngrrz: jhqj * hsqh\r\nnfpt: bzss + pnjg\r\nvfcv: lmfg * phhf\r\nlbqn: 19\r\nhfst: fvzt + rpnz\r\nfmmd: 2\r\ncdrp: 5\r\njpzh: hhbc * zpqh\r\nchrc: fwpb + rtcn\r\nnflm: zhsf * bwtt\r\nzrhr: cjfh + strj\r\ntdtz: jvbn * cnlm\r\nvdhc: 3\r\nptpg: fnwz * nqqn\r\nvdqt: 4\r\nmqcr: dqmq + njht\r\nwmvl: 6\r\nwqpq: mlgg + pmqb\r\npbvg: 3\r\nmztm: 4\r\ntczc: 11\r\ntrmr: qvpb * rzcv\r\nmsth: vgrw + tjzz\r\ncztz: 5\r\nfmzr: gzpd + rmgd\r\nvqnw: nshm + jscf\r\nhghq: zgrl + nmhz\r\nflcm: 5\r\nqfmj: jmtd * fgdr\r\nzplg: 2\r\nlwns: mzcv + dbps\r\nclmq: 5\r\nstwf: wmqn / fgqh\r\nhcfp: 2\r\ndqlh: 17\r\ndmjh: drwm * mbfg\r\njrbl: tczz - dvpj\r\nvdgn: nlbv * bhbr\r\nfnbj: 2\r\nlbft: 3\r\nqvvr: lvcf + jnmz\r\nfdts: 18\r\nbhqn: jfvz * gvsp\r\nsnvf: 2\r\njrmz: 17\r\ntgrs: mzgc + pdbp\r\ngfwz: 3\r\ndvdp: ccwj * zglm\r\nlfcf: 6\r\nbznt: wqpq + gdvz\r\nzqnm: jsfd + smgj\r\ngbmj: 5\r\nrgpl: 9\r\nsnds: 5\r\njzbv: 2\r\npbwh: cljd + spls\r\njvtq: 3\r\nzgsq: cdlf + lqbg\r\nrwls: 11\r\ngssj: gcbr - ctjs\r\nphzl: vtqm * dzmr\r\ndnzj: 17\r\nspls: vdqt * lcjl\r\nwrdj: hmld + fsll\r\ngbsg: 3\r\nwzqw: dvrs * zlqs\r\nhncc: 5\r\nmpmf: 7\r\nmsjw: 3\r\nmggn: pgfz * tcjr\r\njzsl: 13\r\nhpgz: 16\r\npngb: 2\r\njqfw: 5\r\ncgrn: hvrw - hggd\r\ntcmv: tqgq + vfnh\r\ntzgl: 5\r\nbtbt: 2\r\nsbzb: 13\r\nnpcq: 12\r\ngpmm: wttd + jpjh\r\nwcqf: cgtt / vwzb\r\nmhnw: tmnh - qrcc\r\nrrjs: 2\r\nmftj: 4\r\nwjqq: mbjq * vjbp\r\npvcc: 2\r\nzgsd: 4\r\nllgf: bbpv + vfqd\r\nbffs: 12\r\nntzf: pjmp - wpmj\r\ncjqr: vcfg + nwnt\r\nccff: 4\r\nvfrw: 4\r\nnlgs: jmcc + ltnn\r\nhtbq: blfn * llrs\r\npsrm: llhd / wtsp\r\ncnvp: 2\r\nssfd: 4\r\nszmh: 6\r\nzjsm: vpnv * wltg\r\nlbhn: 2\r\nwdcl: bczr * rhhc\r\ntscr: mlwc - sfmq\r\nhzlb: 3\r\ndttr: 11\r\nhhwj: 3\r\nbbhs: 2\r\nmtth: tltd + ddfr\r\nqdpj: wnqq * lcgn\r\nnhvj: sfrw * hzbc\r\nhfql: 2\r\nmbpn: cwlg * vcpv\r\ntczz: fhqz * cjns\r\nfvzt: 5\r\nfzdp: 3\r\nzwsf: 16\r\nncnl: rrjv * tqss\r\nrrbj: 4\r\ngqzs: 5\r\nsrzw: 5\r\ntvvc: hsgz * clzb\r\njvrb: mfbb * zjqc\r\njtgr: 10\r\nhpnp: qdwp / bvbc\r\nwcjn: crdz + cfpv\r\nrbbm: 3\r\nwmcf: bvwd * jgfg\r\nstth: hmmm * pgwf\r\nnpnb: flvl - bnbr\r\nvwsn: 4\r\npqmw: ffhl - tmqs\r\npdgc: wtvj * vhgt\r\nhcwz: 5\r\ntdwg: cmhh * ndpz\r\nhgmm: ptqs * fbgh\r\nlmlb: 15\r\nqgff: 5\r\ndgfm: wjfb - trjr\r\ntnrd: 2\r\nhptb: 2\r\nlhrf: tncj * jtpb\r\nznmp: 1\r\nwvgb: 11\r\nnlrm: 2\r\nlbqw: jvlq + jmqt\r\nggtd: 6\r\ntngv: pjgq + mbfj\r\nfvts: nptd * mtwg\r\nrljr: 3\r\nlqsz: 2\r\ngfnm: hgsr * psvp\r\npzws: 2\r\nhvwz: 2\r\njgvq: thrv * rpwl\r\nzfpm: hbnc * cnrt\r\ncvfn: smfb + nczf\r\nwcvg: mptg / nfqw\r\ncnhn: vbms * gslz\r\npgfz: 5\r\nbsrc: bwrp + hlhs\r\nhpbz: 8\r\nlwwg: cjzw * mfpd\r\ntfgl: ltmj * mjmj\r\njrfg: 11\r\nccsj: dswq + vdrd\r\nztqc: hpgz * ssfd\r\nqljh: 2\r\nfznv: 4\r\njrrd: 5\r\nszhg: bnjf * cwjz\r\nhfcj: 2\r\nctth: 5\r\npmrj: cqrm / lfmd\r\nvmjm: 2\r\njnlt: 3\r\nsfrw: rgpl + ztbc\r\njmwv: zjsm + pdgc\r\nvhnl: 5\r\nqdmr: fbwp / lztn\r\nddqs: prsn + bznt\r\nzdvc: llpf * lntb\r\nvrnh: sfgc * dwdd\r\ndbtc: 3\r\nvbwn: 3\r\nwhmj: hplz + lqtr\r\nmfzd: 5\r\nlzsm: 5\r\njrvm: jzsl * hvwz\r\nfqtl: ncrn * zhbv\r\npsct: rfjb * gqfr\r\nhbzm: 12\r\nlmhv: gfmp - gwrz\r\ngzhl: dgww * lrvc\r\nphgn: 7\r\npnjg: bfvw + mcqr\r\ncpsd: hbzm - bzqq\r\nwfgr: pswm + qmfm\r\njqnh: ctwv + hwrv\r\nwrcp: lvvn - npnb\r\nlnzw: 3\r\nqwsr: cpsd * nwcs\r\nfzwt: 7\r\nscpp: 2\r\nlqsw: humn + wpwd\r\nwpjf: jrmz * tspj\r\nzpmr: 5\r\nlpqw: 4\r\npngr: 1\r\nzwbb: 5\r\nbjdz: jvdc - dsgc\r\nfvht: 11\r\nlpfw: 4\r\nqhnb: jcqj * spbq\r\nrpnz: bnqs + qjnd\r\nrftg: tdtz * ntcb\r\nmflr: qftb * grgj\r\nggcv: 2\r\nlztn: 2\r\nztdl: 2\r\nbvrp: 2\r\nqpgj: hmhl * fnzq\r\nctjs: 5\r\nqqtc: jrzr * lgtr\r\nmbjq: tlwp + tpsq\r\nnshg: tflh + dqhd\r\nphqm: mlpm - cvzv\r\nnrtw: 20\r\npbzj: bgpf + npvh\r\npbdd: qvpm * hnmz\r\nnhvt: cmts + mcqz\r\nbmcv: dbsv * jhmw\r\nqvpm: qrrv + gclw\r\ndplh: dgsq * lrmd\r\nntqg: jwbb * dbmv\r\nlpzq: nzhm * djzq\r\nrbpw: 4\r\nhlsq: hhgm * jcfl\r\nrhqh: 7\r\ntttg: ntcf * msnt\r\nrpfb: 8\r\njsrr: cbls * nhzs\r\ndpmt: 5\r\nqmfc: lqgv / cmdd\r\nmtvn: 1\r\nlnvr: fzdp * jllw\r\npfjr: 5";

        static Regex parsingRegex = new Regex(@"(?<monkeyName>[a-z]+): ((?<leftParent>[a-z]+) (?<operation>.) (?<rightParent>[a-z]+)|(?<number>\d+))");

        public static void Run()
        {
            Dictionary<string, Monkey> monkeys = Input2Monkeys(input);

            //Part 1
            foreach (Monkey monkey in monkeys.Values)
            {
                if (monkey.number.HasValue && monkey.children.Count > 0)
                {
                    monkey.RecursivelyCalculate();
                }
            }
            long? rootNumber = monkeys["root"].number;
            if (!rootNumber.HasValue)
            {
                throw new Exception($"Failed to find root value.");
            }
            else
            {
                Console.WriteLine($"Root monkey has number: {rootNumber.Value}");
            }

            //Part 2
            monkeys = Input2Monkeys(input); //Just regenerate the input
            Monkey root = monkeys["root"];
            Monkey humn = monkeys["humn"];
            root.operation = '=';
            humn.number = null;
            //We remove humn's number and recalculate the tree. This will result in almost everything being solved,
            //except a chain of monkeys forming a path inbetween humn and root. Which is what we want, really.
            foreach (Monkey monkey in monkeys.Values)
            {
                if (monkey.number.HasValue && monkey.children.Count > 0)
                {
                    monkey.RecursivelyCalculate();
                }
            }
            long? rootValueLeft = root.parents[0].number;
            long? rootValueRight = root.parents[1].number;
            long finalValue;
            if (rootValueLeft.HasValue)
            {
                finalValue = rootValueLeft.Value;
            }
            else if (rootValueRight.HasValue)
            {
                finalValue = rootValueRight.Value;
            }
            else
            {
                throw new Exception("Could not find any number in root's parents!");
            }

            //The way we'll calculate Part 2 is by tracing a path from root to humn.
            //We know what root's 2nd value should be, so we'll use that as a base and sequentially undo each operation in the chain.
            //At the end of the chain is humn, so we'll know what humn should say.
            List<Monkey>? chainToRoot = root.RecursivelyFindMonkey(humn, null);
            if(chainToRoot is null)
            {
                throw new Exception("Could not trace a path from root to humn!");
            }

            //Example chain: ptdq = humn - 3, lgvd = 2 * ptdq, cczh = 4 + lgvd, pppw = cczh / 4, root = pppw = 150
            Console.WriteLine($"Need to reverse-compute {root}!");
            for (int i = chainToRoot.Count - 2; i >= 0; i--) //-2 because the last entry is already a known number
            {
                Monkey link = (Monkey)chainToRoot[i];
                char? operation = link.operation;
                if (!operation.HasValue)
                {
                    throw new Exception("Missing operation!");
                }
                //The order of operators matters, so we have 3 different cases depending on whether the known value is on the left or right
                long? linkValueLeft = link.parents[0].number;
                long? linkValueRight = link.parents[1].number;

                //Console.WriteLine($"{link.name} equals {finalValue}. And since {link}...");
                long? calculatedValue = null;
                if (linkValueRight.HasValue) // Link (known) = Parent B (known) <operation> Parent A (unknown)
                {
                    //A = X <op> B
                    long a = finalValue;
                    long b = linkValueRight.Value;
                    //Easily solved as A <inverse_op> B = X
                    //A = X + B -> A - B = X
                    //A = X * B -> A / B = X
                    //A = X - B -> A + B = X
                    //A = X / B -> A * B = X
                    calculatedValue = PerformCalculation(a, b, InverseOperation(operation.Value));
                    Console.WriteLine($"{link.parents[0].name} = {calculatedValue} = {a} {InverseOperation(operation.Value)} {b}!");
                }
                else if (linkValueLeft.HasValue) // Link (known) = Parent A (unknown) <operation> Parent B (known)
                {
                    //A = B <op> X
                    long a = finalValue;
                    long b = linkValueLeft.Value;
                    //This is trickier to isolate.
                    if(operation.Value == '-' || operation.Value == '/')
                    {
                        //First case...
                        //B <op> A = X
                        //A = B - X -> B - A = X
                        //A = B / X -> B / A = X
                        calculatedValue = PerformCalculation(b, a, operation.Value);
                        Console.WriteLine($"{link.parents[1].name} = {calculatedValue} = {b} {operation.Value} {a}!");
                    }
                    else
                    {
                        //Second case...
                        //A <inverse_op> B = X
                        //A = B + X -> A - B = X
                        //A = B * X -> A / B = X
                        calculatedValue = PerformCalculation(a, b, InverseOperation(operation.Value));
                        Console.WriteLine($"{link.parents[1].name} = {calculatedValue} = {a} {InverseOperation(operation.Value)} {b}!");
                    }
                }
                if(!calculatedValue.HasValue)
                {
                    throw new Exception("Could not compute operation!");
                }
                finalValue = calculatedValue.Value;
            }
            Console.WriteLine($"Humn should say: {finalValue}!");
            humn.number = finalValue;
            //For the heck of it, we can now finish the rest of the tree and verify that the value is correct.
            humn.RecursivelyCalculate();
            Console.WriteLine($"Verifying... {root}!");
        }

        public static Dictionary<string, Monkey> Input2Monkeys(string input)
        {
            Dictionary<string, Monkey> monkeys = new Dictionary<string, Monkey>();
            List<Match> pendingMatches = new List<Match>();
            List<string> inputByLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.
            //Pass 1: We create all the monkeys so we can reference them later.
            foreach (string line in inputByLine)
            {
                Match match = parsingRegex.Match(line);
                if (!match.Success)
                {
                    Debug.Fail($"Could not parse {line}!");
                }
                string monkeyName = match.Groups["monkeyName"].Value;
                monkeys.Add(monkeyName, new Monkey(monkeyName));
                pendingMatches.Add(match);
            }
            //Pass 2: Now we reference the monkeys and their job, so we can finish creating all the Monkey objects.
            foreach (Match match in pendingMatches)
            {
                string monkeyName = match.Groups["monkeyName"].Value;
                Monkey currMonkey = monkeys[monkeyName];
                if (match.Groups["number"].Success)
                {
                    currMonkey.number = long.Parse(match.Groups["number"].Value);
                }
                else
                {
                    currMonkey.operation = char.Parse(match.Groups["operation"].Value);
                    Monkey leftParent = monkeys[match.Groups["leftParent"].Value];
                    Monkey rightParent = monkeys[match.Groups["rightParent"].Value];
                    Debug.Assert(leftParent != null && rightParent != null, "Failed to parse monkey parents!");
                    leftParent.children.Add(currMonkey);
                    rightParent.children.Add(currMonkey);
                    currMonkey.parents = new List<Monkey> { leftParent, rightParent };
                }
            }
            return monkeys;
        }

        public static long? PerformCalculation(long leftNumber, long rightNumber, char operation)
        {
            switch (operation)
            {
                case '+':
                    return leftNumber + rightNumber;
                case '-':
                    return leftNumber - rightNumber;
                case '/':
                    return leftNumber / rightNumber;
                case '*':
                    return leftNumber * rightNumber;
                default:
                    return null;
            }
        }

        static List<char> operations = new() { '+', '-', '*', '/', '=' };
        static List<char> inverseOperations = new() { '-', '+', '/', '*', '=' };
        public static char InverseOperation(char operation)
        {
            return inverseOperations[operations.IndexOf(operation)];
        }

        public class Monkey
        {
            public string name;
            public long? number;
            public char? operation;
            public List<Monkey> children = new();
            public List<Monkey> parents = new();

            public Monkey(string name)
            {
                this.name = name;
            }

            public override string? ToString()
            {
                if (number.HasValue)
                {
                    return $"{name} = {number.Value}";
                }
                else if (parents.Count > 0)
                {
                    Monkey leftParent = parents[0];
                    Monkey rightParent = parents[1];
                    var leftString = leftParent.number.HasValue ? leftParent.number.Value.ToString() : leftParent.name;
                    var rightString = rightParent.number.HasValue ? rightParent.number.Value.ToString() : rightParent.name;
                    return $"{name} = {leftString} {operation} {rightString}";
                }
                else
                {
                    return $"{name} = ???";
                }
            }

            public void RecursivelyCalculate()
            {
                //Console.WriteLine($"Calculating {name}...");
                if (!number.HasValue)
                {
                    TryCalculateNumber();
                }
                if (number.HasValue)
                {
                    //Console.WriteLine($"Eureka! My number is {number.Value}.");
                    foreach (Monkey child in children)
                    {
                        //Console.WriteLine($"Waking up my child {child.name}...");
                        child.RecursivelyCalculate();
                    }
                }
            }

            public System.Collections.Generic.List<Monkey>? RecursivelyFindMonkey(Monkey monkey, List<Monkey>? sequence)
            {
                if (parents.Count == 0)
                {
                    return null;
                }
                if (parents.Contains(monkey))
                {
                    return new List<Monkey>() { this };
                }
                foreach (Monkey parent in parents)
                {
                    List<Monkey>? newSeq = parent.RecursivelyFindMonkey(monkey, null);
                    if (newSeq != null)
                    {
                        newSeq.Add(this);
                        return newSeq;
                    }
                }
                return null;
            }

            public bool TryCalculateNumber()
            {
                long? leftVal = parents[0].number;
                long? rightVal = parents[1].number;
                if (!leftVal.HasValue || !rightVal.HasValue || !operation.HasValue)
                {
                    return false;
                }
                long? temp = PerformCalculation(leftVal.Value, rightVal.Value, operation.Value);
                if (temp.HasValue)
                {
                    number = temp.Value;
                    return true;
                }
                return false;
            }
        }
    }
}

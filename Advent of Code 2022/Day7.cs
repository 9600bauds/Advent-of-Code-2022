using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day7
    {
        //https://adventofcode.com/2022/day/7

        static Regex startListingRegex = new Regex(@"\$ ls");
        static Regex changeDirectoryRegex = new Regex(@"\$ cd (?<newDir>[a-z\/\.]+)");
        static Regex fileFoundRegex = new Regex(@"(?<filesize>\d+) (?<filename>[a-z\.]+)");
        static Regex dirFoundRegex = new Regex(@"dir (?<foundDir>[a-z]+)");

        class ElfFile
        {
            public String name;
            public long filesize;
            public ElfDirectory directory;

            public ElfFile(string name, long filesize, ElfDirectory directory)
            {
                this.name = name;
                this.filesize = filesize;
                this.directory = directory;
            }
        }

        class ElfDirectory
        {
            public string name;
            public ElfDirectory parent;
            public Dictionary<String, ElfDirectory> subdirectories = new Dictionary<String, ElfDirectory>();
            public Dictionary<String, ElfFile> files = new Dictionary<String, ElfFile>();

            public ElfDirectory(string name, ElfDirectory parent)
            {
                this.name = name;
                this.parent = parent;
            }

            public ElfDirectory() //annoying that I have to declare this
            {
            }

            public override String ToString()
            {
                if (parent == null)
                {
                    return ""; //root
                }
                return $"{parent.ToString()}/{name}";
            }

            public string GetListing(int depth = 0)
            {
                String listing = "";
                String padding = "";
                for(int i = 0; i < depth; i++)
                {
                    padding += "  ";
                }
                listing += $"{padding}- {name} (dir)\r\n";
                foreach (ElfDirectory dir in subdirectories.Values)
                {
                    listing += dir.GetListing(depth + 1);
                }
                foreach(ElfFile file in files.Values)
                {
                    listing += $"{padding}  - {file.name} (file, size={file.filesize})\r\n";
                }
                return listing;
            }

            public long GetTotalSize(bool includeSubdirectories = true)
            {
                long total = 0;
                if (includeSubdirectories)
                {
                    foreach (ElfDirectory dir in subdirectories.Values)
                    {
                        total += dir.GetTotalSize(includeSubdirectories);
                    }
                }
                foreach (ElfFile file in files.Values)
                {
                    total += file.filesize;
                }
                return total;
            }
        }

        public static void Run()
        {
            //String input = "$ cd /\r\n$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d\r\n$ cd a\r\n$ ls\r\ndir e\r\n29116 f\r\n2557 g\r\n62596 h.lst\r\n$ cd e\r\n$ ls\r\n584 i\r\n$ cd ..\r\n$ cd ..\r\n$ cd d\r\n$ ls\r\n4060174 j\r\n8033020 d.log\r\n5626152 d.ext\r\n7214296 k";
            String input = "$ cd /\r\n$ ls\r\ndir fchrtcbh\r\ndir hlnbrj\r\ndir jbt\r\ndir nnn\r\n57400 pfqcbp\r\ndir qsdv\r\ndir tdl\r\ndir tmcpgtz\r\n$ cd fchrtcbh\r\n$ ls\r\ndir fct\r\ndir fwttfps\r\n61765 nlr\r\n28736 pfqcbp.pfg\r\n224426 qcmtlbss\r\n145764 sgpmfdlt.tnd\r\n273765 wzmrclw.qbq\r\n$ cd fct\r\n$ ls\r\ndir ctzphlhl\r\n$ cd ctzphlhl\r\n$ ls\r\n25094 cfmw.rdv\r\n$ cd ..\r\n$ cd ..\r\n$ cd fwttfps\r\n$ ls\r\n69990 hdf.fjn\r\n146885 hqrzgvgn.wqp\r\n21206 wzmrclw.qbq\r\n$ cd ..\r\n$ cd ..\r\n$ cd hlnbrj\r\n$ ls\r\ndir mbwgsdcv\r\n$ cd mbwgsdcv\r\n$ ls\r\n156396 rdm.ttb\r\n$ cd ..\r\n$ cd ..\r\n$ cd jbt\r\n$ ls\r\ndir bbm\r\ndir gqbvgbt\r\ndir hzjzlwv\r\ndir jcstr\r\ndir llf\r\n$ cd bbm\r\n$ ls\r\ndir nsshzppb\r\ndir pfqcbp\r\ndir tdz\r\ndir tvqh\r\n$ cd nsshzppb\r\n$ ls\r\n5640 bvpnq.tbm\r\n241745 cmjshlw.qjh\r\ndir jlcqcb\r\n78459 nlfv.dgr\r\ndir pfqcbp\r\n245461 rjftj.gtj\r\n169808 tgvqrvq.mrw\r\n$ cd jlcqcb\r\n$ ls\r\n314748 fzsvgrcw\r\n32649 mmbfqp.lqc\r\ndir nzpvt\r\ndir pmncbz\r\ndir qqtlm\r\n321229 shtc.vtw\r\n10052 tdz\r\n320999 tdz.vfc\r\n$ cd nzpvt\r\n$ ls\r\ndir fct\r\ndir lbsng\r\n209182 nlr\r\ndir pfqcbp\r\n243321 srt.tqh\r\n3325 tdz.dbz\r\n332295 wzmrclw.qbq\r\n$ cd fct\r\n$ ls\r\n185072 drcmppfs\r\ndir fct\r\n92835 nlr\r\n$ cd fct\r\n$ ls\r\n230981 bpnvm\r\n$ cd ..\r\n$ cd ..\r\n$ cd lbsng\r\n$ ls\r\ndir mzsj\r\n116041 nzpvt.nll\r\n$ cd mzsj\r\n$ ls\r\n279834 vshfrzsg\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfqcbp\r\n$ ls\r\ndir fct\r\n173141 mzb.lcd\r\ndir ssbv\r\n$ cd fct\r\n$ ls\r\n33372 tjznm\r\n$ cd ..\r\n$ cd ssbv\r\n$ ls\r\n273126 bccsm.rqq\r\n298840 cqzglqw.ppf\r\ndir fct\r\ndir pmqj\r\n126839 qdvm.wsc\r\n$ cd fct\r\n$ ls\r\n323437 bcqms.cbt\r\n91849 drcmppfs\r\n103408 jbmbrg.ggs\r\n261735 mnfrhs\r\n326197 wvrj.pzg\r\n$ cd ..\r\n$ cd pmqj\r\n$ ls\r\n34310 vhpqwp\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd pmncbz\r\n$ ls\r\n102403 rjhq.blj\r\n$ cd ..\r\n$ cd qqtlm\r\n$ ls\r\ndir ggjzcsfn\r\ndir nzpvt\r\n134921 wzmrclw.qbq\r\n$ cd ggjzcsfn\r\n$ ls\r\ndir nlfv\r\n$ cd nlfv\r\n$ ls\r\n219183 nbfqvdhb.pgr\r\n$ cd ..\r\n$ cd ..\r\n$ cd nzpvt\r\n$ ls\r\n141177 fct.bmj\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfqcbp\r\n$ ls\r\n312723 ngbm\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfqcbp\r\n$ ls\r\ndir bvsj\r\n120921 cmzmmlqq.pqn\r\n308093 drcmppfs\r\ndir gvndh\r\n151290 hsjgzcf\r\n74851 tdz\r\n294395 wfp.lgp\r\n$ cd bvsj\r\n$ ls\r\n218258 qlnhddbw.pql\r\ndir sdjddn\r\n$ cd sdjddn\r\n$ ls\r\ndir tdl\r\ndir trpcd\r\n$ cd tdl\r\n$ ls\r\n271008 sqdggvm.hbh\r\n$ cd ..\r\n$ cd trpcd\r\n$ ls\r\n119088 wzmrclw.qbq\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd gvndh\r\n$ ls\r\ndir bvg\r\ndir hsqmsqt\r\n125116 pfqcbp.fpb\r\n182960 wfp.lgp\r\n$ cd bvg\r\n$ ls\r\n183661 wzmrclw.qbq\r\n$ cd ..\r\n$ cd hsqmsqt\r\n$ ls\r\ndir bmvcv\r\n$ cd bmvcv\r\n$ ls\r\n85871 nlfv\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\ndir nzpvt\r\n$ cd nzpvt\r\n$ ls\r\ndir ttcwr\r\n$ cd ttcwr\r\n$ ls\r\n58678 wfp.lgp\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd tvqh\r\n$ ls\r\n111924 bccsm.rqq\r\n155539 drcmppfs\r\ndir hvqgrlb\r\ndir njqd\r\n67089 nlr\r\ndir nzpvt\r\n109311 nzpvt.bzz\r\n249415 nzpvt.ptr\r\ndir srq\r\ndir tdz\r\ndir vjdjl\r\ndir zmgzph\r\n$ cd hvqgrlb\r\n$ ls\r\ndir fct\r\n105914 jqtjglmh.glw\r\n94476 mst\r\n180432 nbb.fvv\r\ndir nhnp\r\ndir nlfv\r\n$ cd fct\r\n$ ls\r\n67110 fct\r\n310128 gdzswr.phr\r\n67231 mjbjvb.ngb\r\n285357 vtnlzs.slj\r\ndir zzl\r\n$ cd zzl\r\n$ ls\r\n118330 bccsm.rqq\r\n317825 cchprc\r\n$ cd ..\r\n$ cd ..\r\n$ cd nhnp\r\n$ ls\r\n302625 cwt\r\n319999 htrj.mgt\r\n$ cd ..\r\n$ cd nlfv\r\n$ ls\r\ndir tdz\r\n$ cd tdz\r\n$ ls\r\n127844 bccsm.rqq\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd njqd\r\n$ ls\r\n27880 jpscpmzn.thz\r\ndir ntrnlms\r\ndir nzpvt\r\n41048 pfqcbp.qzf\r\ndir vtvwjhm\r\n$ cd ntrnlms\r\n$ ls\r\n15229 sfr\r\n$ cd ..\r\n$ cd nzpvt\r\n$ ls\r\ndir fct\r\ndir ltzw\r\ndir sfwhmn\r\ndir tdz\r\n$ cd fct\r\n$ ls\r\n185362 fddlqjnn\r\n$ cd ..\r\n$ cd ltzw\r\n$ ls\r\n290023 wslq\r\n$ cd ..\r\n$ cd sfwhmn\r\n$ ls\r\ndir jmgzcqvd\r\n159166 mfdhjq\r\n15995 nddsdb.tcg\r\n173881 pqnh.nvt\r\n37665 qnbbmgtl.vcg\r\n275256 tdz.zrs\r\n$ cd jmgzcqvd\r\n$ ls\r\ndir dtr\r\n$ cd dtr\r\n$ ls\r\ndir tdz\r\n$ cd tdz\r\n$ ls\r\n12772 mzmpvqrt\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\ndir fgd\r\ndir pfqcbp\r\ndir tdz\r\n137421 vttcn.mgp\r\n308378 wzmrclw.qbq\r\n$ cd fgd\r\n$ ls\r\n75974 gdzrjn\r\ndir zfvwp\r\n$ cd zfvwp\r\n$ ls\r\n48696 nlr\r\n$ cd ..\r\n$ cd ..\r\n$ cd pfqcbp\r\n$ ls\r\n126220 wfp.lgp\r\n68328 zshscwhf.wvm\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\ndir gwpps\r\ndir zdbsq\r\n$ cd gwpps\r\n$ ls\r\n193706 bccsm.rqq\r\n$ cd ..\r\n$ cd zdbsq\r\n$ ls\r\n90049 vqwwh\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd vtvwjhm\r\n$ ls\r\n291688 bccsm.rqq\r\ndir dnjgl\r\n17554 drcmppfs\r\n$ cd dnjgl\r\n$ ls\r\ndir lpdzhhf\r\ndir nlfv\r\ndir nmbrz\r\n168524 vbgwhhnq\r\n$ cd lpdzhhf\r\n$ ls\r\n317727 nlfv.wsf\r\n75497 nlr\r\n105712 wfp.lgp\r\n$ cd ..\r\n$ cd nlfv\r\n$ ls\r\n121726 fct.lsw\r\n$ cd ..\r\n$ cd nmbrz\r\n$ ls\r\n14788 bccsm.rqq\r\ndir cjv\r\n64895 cqndrd.rbb\r\ndir fnmsjd\r\ndir hgzgq\r\ndir hst\r\n33320 nlfv.wwb\r\n111373 nlr\r\n271844 nzpvt.llp\r\ndir pfqcbp\r\n$ cd cjv\r\n$ ls\r\n108233 wfp.lgp\r\n$ cd ..\r\n$ cd fnmsjd\r\n$ ls\r\n108902 drcmppfs\r\ndir fbnmdwmw\r\ndir jzq\r\ndir tdz\r\n$ cd fbnmdwmw\r\n$ ls\r\n183892 wzmrclw.qbq\r\n$ cd ..\r\n$ cd jzq\r\n$ ls\r\ndir nzpvt\r\n$ cd nzpvt\r\n$ ls\r\n34417 gjqc\r\n$ cd ..\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\ndir cmnw\r\n$ cd cmnw\r\n$ ls\r\n224596 nzpvt\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd hgzgq\r\n$ ls\r\n260727 bbqfd.cnm\r\ndir nzpvt\r\n302916 rclhngqn.dvh\r\ndir rhqj\r\ndir tdz\r\n168589 wzmrclw.qbq\r\ndir zfgf\r\n$ cd nzpvt\r\n$ ls\r\n212040 nzpvt\r\n196163 pfr.hpn\r\n$ cd ..\r\n$ cd rhqj\r\n$ ls\r\n36358 frfpn.bwd\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\n7924 pfqcbp\r\n$ cd ..\r\n$ cd zfgf\r\n$ ls\r\n190752 nwntvrf.rns\r\n$ cd ..\r\n$ cd ..\r\n$ cd hst\r\n$ ls\r\n327527 bccsm.rqq\r\n90170 nlr\r\n$ cd ..\r\n$ cd pfqcbp\r\n$ ls\r\n163268 fct.qtw\r\n1178 fct.shw\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd nzpvt\r\n$ ls\r\n256871 bccsm.rqq\r\n219823 pfqcbp\r\ndir swtrnt\r\n146203 tdwv\r\n150052 wfp.lgp\r\n123164 zqmq\r\n$ cd swtrnt\r\n$ ls\r\ndir fct\r\n$ cd fct\r\n$ ls\r\n7540 nzpvt.lbv\r\n133952 tdz.rqf\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd srq\r\n$ ls\r\n294836 tdz.rrc\r\n192802 wzmrclw.qbq\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\n255394 bccsm.rqq\r\n99901 nlfv.vfj\r\n316469 pbzcjplt.fgf\r\n104809 tjjmtzdc.jcq\r\n$ cd ..\r\n$ cd vjdjl\r\n$ ls\r\n60934 fct.jts\r\n270669 mmj.mqp\r\ndir nlfv\r\ndir nzpvt\r\n70744 qqjmpvh.dzv\r\ndir szrvs\r\ndir wmbbn\r\n$ cd nlfv\r\n$ ls\r\ndir bnjtlh\r\n132341 drcmppfs\r\ndir gmvjtj\r\ndir gzdj\r\ndir hpvrj\r\n49932 sqvz\r\ndir tdz\r\n$ cd bnjtlh\r\n$ ls\r\ndir fct\r\n255578 mftscrq\r\ndir nlfv\r\n76061 nlfv.bqm\r\n$ cd fct\r\n$ ls\r\n269563 wfp.lgp\r\n$ cd ..\r\n$ cd nlfv\r\n$ ls\r\n198725 ghh\r\n$ cd ..\r\n$ cd ..\r\n$ cd gmvjtj\r\n$ ls\r\n18219 fbhj.pjw\r\n41025 mchtc\r\n$ cd ..\r\n$ cd gzdj\r\n$ ls\r\n113277 dnzl\r\ndir fzhwfr\r\n133044 lrlfq.ndr\r\n120088 qcrv.mrs\r\ndir wgvw\r\n$ cd fzhwfr\r\n$ ls\r\n300485 gbcc\r\n71468 nzpvt.ztg\r\n180837 wfp.lgp\r\n$ cd ..\r\n$ cd wgvw\r\n$ ls\r\n123989 drcmppfs\r\n2266 pfqcbp.ccd\r\n$ cd ..\r\n$ cd ..\r\n$ cd hpvrj\r\n$ ls\r\n270481 bccsm.rqq\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\n289817 bnp.wfp\r\n$ cd ..\r\n$ cd ..\r\n$ cd nzpvt\r\n$ ls\r\ndir bnt\r\ndir dtsr\r\ndir rhqrs\r\ndir tdz\r\n42376 wfp.lgp\r\n$ cd bnt\r\n$ ls\r\ndir gjdqwnd\r\n112688 nzpvt.bgh\r\n15859 nzpvt.ftj\r\n219526 nzpvt.gnt\r\ndir rwr\r\ndir tfvgnz\r\ndir ztpflr\r\n$ cd gjdqwnd\r\n$ ls\r\ndir ghsbcb\r\ndir gnnnslbh\r\ndir nnnh\r\n$ cd ghsbcb\r\n$ ls\r\n330485 bqnn.wsv\r\n148644 qvnl.rcw\r\n$ cd ..\r\n$ cd gnnnslbh\r\n$ ls\r\ndir fct\r\ndir nnp\r\ndir nzpvt\r\n152038 rlqsp.vsj\r\n118099 srsjsm\r\ndir vdjzwgz\r\n300404 zcjfnthp\r\n$ cd fct\r\n$ ls\r\n249569 hmpwz.ldw\r\n$ cd ..\r\n$ cd nnp\r\n$ ls\r\n232389 nhfhwbv\r\n$ cd ..\r\n$ cd nzpvt\r\n$ ls\r\n328734 phdw\r\n$ cd ..\r\n$ cd vdjzwgz\r\n$ ls\r\n130149 ttjzr.pjw\r\ndir zslhwc\r\n$ cd zslhwc\r\n$ ls\r\ndir lmhbnvzc\r\n$ cd lmhbnvzc\r\n$ ls\r\n316145 pfqcbp.jmd\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd nnnh\r\n$ ls\r\n247235 wfp.lgp\r\n$ cd ..\r\n$ cd ..\r\n$ cd rwr\r\n$ ls\r\n117412 jqncsgtz.srj\r\n$ cd ..\r\n$ cd tfvgnz\r\n$ ls\r\n301735 drcmppfs\r\n$ cd ..\r\n$ cd ztpflr\r\n$ ls\r\ndir pfscczq\r\n$ cd pfscczq\r\n$ ls\r\n258369 mmwrjjg.snm\r\n208621 qrn.bws\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd dtsr\r\n$ ls\r\n226917 cdgn\r\n58590 gqmp.bjw\r\n220622 nlr\r\n97205 tdz.lmf\r\n$ cd ..\r\n$ cd rhqrs\r\n$ ls\r\ndir bhrb\r\n$ cd bhrb\r\n$ ls\r\n98744 nzpvt.sgl\r\n$ cd ..\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\n253051 cgn.fwb\r\n41573 qrvqml.vsj\r\n$ cd ..\r\n$ cd ..\r\n$ cd szrvs\r\n$ ls\r\n195204 dhdrjswp\r\n299349 drcmppfs\r\n2890 rzrc.bnd\r\n$ cd ..\r\n$ cd wmbbn\r\n$ ls\r\n248063 nzpvt\r\n56979 zpztvv\r\n$ cd ..\r\n$ cd ..\r\n$ cd zmgzph\r\n$ ls\r\n181700 bccsm.rqq\r\n322580 fzf.pdg\r\n189013 gpcrqlc\r\n260640 rwt\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd gqbvgbt\r\n$ ls\r\ndir jlh\r\ndir rvdfpd\r\n$ cd jlh\r\n$ ls\r\n47327 bccsm.rqq\r\ndir mlwz\r\n$ cd mlwz\r\n$ ls\r\n252054 tlg.lfd\r\n$ cd ..\r\n$ cd ..\r\n$ cd rvdfpd\r\n$ ls\r\n102223 cdmd.rzl\r\n120439 lnr\r\n$ cd ..\r\n$ cd ..\r\n$ cd hzjzlwv\r\n$ ls\r\n6753 czzvcvgc.qrw\r\n132168 wzmrclw.qbq\r\n$ cd ..\r\n$ cd jcstr\r\n$ ls\r\n224805 cvnfppdv\r\n$ cd ..\r\n$ cd llf\r\n$ ls\r\ndir dzpzvjw\r\ndir gvq\r\n131774 nlfv.llj\r\n$ cd dzpzvjw\r\n$ ls\r\n284397 dfdtpgsz.cdw\r\ndir fct\r\ndir pfqcbp\r\n210819 qvbzr\r\ndir sztbm\r\n$ cd fct\r\n$ ls\r\n242208 nlfv.zmb\r\n183434 pfqcbp\r\n224189 vdfzrvm.jlf\r\n222688 wfp.lgp\r\n291920 wzmrclw.qbq\r\n$ cd ..\r\n$ cd pfqcbp\r\n$ ls\r\ndir pfqcbp\r\n$ cd pfqcbp\r\n$ ls\r\n60445 tdz\r\n$ cd ..\r\n$ cd ..\r\n$ cd sztbm\r\n$ ls\r\n165502 mcqlcmc.rbp\r\n$ cd ..\r\n$ cd ..\r\n$ cd gvq\r\n$ ls\r\ndir dwtj\r\ndir fnmvrslw\r\ndir tdz\r\ndir vndm\r\n$ cd dwtj\r\n$ ls\r\ndir qtrqhh\r\n$ cd qtrqhh\r\n$ ls\r\n115781 tdz.nzv\r\n123358 wfp.lgp\r\n$ cd ..\r\n$ cd ..\r\n$ cd fnmvrslw\r\n$ ls\r\ndir brzzr\r\n29456 fct.fqz\r\n257982 nlfv\r\n$ cd brzzr\r\n$ ls\r\n195396 mlsszsf\r\n309844 nlfv\r\n$ cd ..\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\ndir stwrprz\r\ndir zmrm\r\n$ cd stwrprz\r\n$ ls\r\n143929 slfbtj.qtz\r\n$ cd ..\r\n$ cd zmrm\r\n$ ls\r\n128440 nlr\r\n$ cd ..\r\n$ cd ..\r\n$ cd vndm\r\n$ ls\r\ndir dnzlnmzc\r\ndir fct\r\n$ cd dnzlnmzc\r\n$ ls\r\n73389 nvdznjtw.fqp\r\n51123 rcrtl.fwc\r\n$ cd ..\r\n$ cd fct\r\n$ ls\r\n14933 drcmppfs\r\n324404 drm.fmg\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd nnn\r\n$ ls\r\ndir pfqcbp\r\ndir rlvfd\r\n$ cd pfqcbp\r\n$ ls\r\n285385 lspfqghn.ccl\r\n90876 nlr\r\n$ cd ..\r\n$ cd rlvfd\r\n$ ls\r\n198026 wpzg\r\n$ cd ..\r\n$ cd ..\r\n$ cd qsdv\r\n$ ls\r\n32915 fct.psc\r\n86919 qfzsfz\r\n$ cd ..\r\n$ cd tdl\r\n$ ls\r\n320007 tdbpggtw\r\n$ cd ..\r\n$ cd tmcpgtz\r\n$ ls\r\ndir brbn\r\ndir brt\r\n101599 hdtg.bbb\r\ndir jhz\r\ndir rbdbtd\r\ndir tdz\r\ndir trflnpmw\r\ndir wldfm\r\n$ cd brbn\r\n$ ls\r\ndir hfdlq\r\n145067 wfp.lgp\r\n$ cd hfdlq\r\n$ ls\r\n43395 htshjzd\r\n$ cd ..\r\n$ cd ..\r\n$ cd brt\r\n$ ls\r\n82871 drcmppfs\r\ndir fct\r\ndir qnghcq\r\ndir tgmrlh\r\n$ cd fct\r\n$ ls\r\n199814 wzmrclw.qbq\r\n$ cd ..\r\n$ cd qnghcq\r\n$ ls\r\n143210 mrqll\r\n162526 nlfv.bbs\r\n$ cd ..\r\n$ cd tgmrlh\r\n$ ls\r\n48165 bccsm.rqq\r\n318013 pfqcbp\r\n$ cd ..\r\n$ cd ..\r\n$ cd jhz\r\n$ ls\r\ndir cqqlhrgf\r\n244294 ftwmblf\r\n334112 gvm.lsw\r\ndir jjtjrsm\r\ndir nhjztw\r\ndir wdqmdszj\r\n238850 wzmrclw.qbq\r\n$ cd cqqlhrgf\r\n$ ls\r\n54323 fct.zrn\r\ndir gslvzq\r\n89225 nzpvt.jwn\r\n170612 vnszlrms.qmm\r\n124897 zcddc\r\n158922 zdzr\r\n$ cd gslvzq\r\n$ ls\r\n132083 nlfv\r\n$ cd ..\r\n$ cd ..\r\n$ cd jjtjrsm\r\n$ ls\r\n66475 vqlqwvd\r\n$ cd ..\r\n$ cd nhjztw\r\n$ ls\r\n128488 bccsm.rqq\r\n319667 nlfv.nql\r\n106856 pfqcbp\r\n$ cd ..\r\n$ cd wdqmdszj\r\n$ ls\r\n224155 zsntbsns.svg\r\n$ cd ..\r\n$ cd ..\r\n$ cd rbdbtd\r\n$ ls\r\n214776 pfqcbp.fwz\r\n$ cd ..\r\n$ cd tdz\r\n$ ls\r\n152287 gfmdcrt\r\ndir jsqd\r\n219555 jvstcp.ngl\r\ndir mmgjzmcc\r\ndir nlfv\r\ndir vpwmlq\r\n$ cd jsqd\r\n$ ls\r\n284781 bcsd.dll\r\ndir dttzdnpb\r\n217660 dvpj.qgq\r\n56055 jzslsrq.zsh\r\ndir nzpvt\r\ndir pfqcbp\r\n220497 tdz.mmv\r\n278405 zzhsgr.bqp\r\n$ cd dttzdnpb\r\n$ ls\r\n23222 pfqcbp.mpq\r\n50335 qdmcgbz.jpp\r\n$ cd ..\r\n$ cd nzpvt\r\n$ ls\r\n128962 gwzvqc.bpj\r\n$ cd ..\r\n$ cd pfqcbp\r\n$ ls\r\n260384 pfqcbp.nfp\r\n$ cd ..\r\n$ cd ..\r\n$ cd mmgjzmcc\r\n$ ls\r\n255325 wzmrclw.qbq\r\n$ cd ..\r\n$ cd nlfv\r\n$ ls\r\ndir cfdj\r\n275703 nlr\r\ndir wlzd\r\n$ cd cfdj\r\n$ ls\r\n244185 wfp.lgp\r\n$ cd ..\r\n$ cd wlzd\r\n$ ls\r\ndir vtpjz\r\n$ cd vtpjz\r\n$ ls\r\n140890 wfp.lgp\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd vpwmlq\r\n$ ls\r\ndir bmtrdpdl\r\ndir cqvdppcg\r\n212696 fct.pnc\r\n32622 fzvsv.hsr\r\n26043 hwmmr\r\n176780 wqd.hbm\r\n$ cd bmtrdpdl\r\n$ ls\r\n145895 pfqcbp.jtp\r\n220677 pllqlvn\r\n49356 wfp.lgp\r\n$ cd ..\r\n$ cd cqvdppcg\r\n$ ls\r\n276847 jgthh.ssc\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd trflnpmw\r\n$ ls\r\ndir gfgn\r\ndir jrlqjsc\r\ndir nlfv\r\ndir phmdq\r\ndir qnvmpzv\r\n311867 tdz\r\n$ cd gfgn\r\n$ ls\r\n255377 bccsm.rqq\r\n317338 pwfq\r\n$ cd ..\r\n$ cd jrlqjsc\r\n$ ls\r\n98803 wzmrclw.qbq\r\n$ cd ..\r\n$ cd nlfv\r\n$ ls\r\ndir fqt\r\n208205 tdfgzdbb.szm\r\n$ cd fqt\r\n$ ls\r\n99816 jcm\r\n11010 nlfv.fsv\r\n215962 nlr\r\n$ cd ..\r\n$ cd ..\r\n$ cd phmdq\r\n$ ls\r\n118845 cmssp.sgc\r\n238930 mdhs.tqd\r\ndir nlfv\r\n277199 qnwb\r\n287223 qpqdrvlf\r\n$ cd nlfv\r\n$ ls\r\n253884 bccsm.rqq\r\n$ cd ..\r\n$ cd ..\r\n$ cd qnvmpzv\r\n$ ls\r\n290671 rlnd.tps\r\n$ cd ..\r\n$ cd ..\r\n$ cd wldfm\r\n$ ls\r\n76173 drcmppfs\r\ndir gbzhcvn\r\ndir hrw\r\n$ cd gbzhcvn\r\n$ ls\r\n18543 nlr\r\n$ cd ..\r\n$ cd hrw\r\n$ ls\r\n260983 wfp.lgp";
            List<String> inputPerLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            ElfDirectory root = new ElfDirectory();
            ElfDirectory currentDirectory = root;
            Dictionary<String, ElfDirectory> allDirectories = new Dictionary<string, ElfDirectory>();
            allDirectories.Add(root.ToString(), root); //Should this be here or not?


            foreach (String line in inputPerLine)
            {
                //Console.WriteLine("---{0}---", line);
                Match match;
                match = startListingRegex.Match(line);
                if (match.Success)
                {
                    //Console.WriteLine("Listing request!");
                    continue;
                }
                match = changeDirectoryRegex.Match(line);
                if (match.Success)
                {
                    String newDir = match.Groups["newDir"].Value;
                    //Console.WriteLine("Changing directory to {0}", newDir);
                    switch (newDir)
                    {
                        case "/":
                            currentDirectory = root;
                            break;
                        case "..":
                            if (currentDirectory.parent == null)
                            {
                                Debug.Fail($"Error! Tried to go up one directory, but we're already at root (or a non-root directory has no parent somehow.) Line: {line}");
                            }
                            currentDirectory = currentDirectory.parent;
                            break;
                        default:
                            if (!currentDirectory.subdirectories.ContainsKey(newDir))
                            {
                                Debug.Fail($"Error! Tried to enter a directory that does not exist, or we don't yet know that it exists. Line: {line}");
                            }
                            currentDirectory = currentDirectory.subdirectories[newDir];
                            break;
                    }
                    //Console.WriteLine("Directory is now {0}.", currentDirectory.ToString());
                    continue;
                }
                match = fileFoundRegex.Match(line);
                if (match.Success)
                {
                    String filename = match.Groups["filename"].Value;
                    long filesize = long.Parse(match.Groups["filesize"].Value);
                    //Console.WriteLine("Found file {0} with size {1}", filename, filesize);
                    if (currentDirectory.files.ContainsKey(filename)) {
                        //Console.WriteLine("Found a file that we already knew about!");
                        continue;
                    }
                    currentDirectory.files.Add(filename, new ElfFile(filename, filesize, currentDirectory));
                    continue;
                }
                match = dirFoundRegex.Match(line);
                if (match.Success)
                {
                    String foundDir = match.Groups["foundDir"].Value;
                    //Console.WriteLine("Found directory named {0}", foundDir);
                    if (currentDirectory.subdirectories.ContainsKey(foundDir))
                    {
                        //Console.WriteLine("Found a directory that we already knew about!");
                        continue;
                    }
                    ElfDirectory newDir = new ElfDirectory(foundDir, currentDirectory);
                    currentDirectory.subdirectories.Add(foundDir, newDir);
                    allDirectories.Add(newDir.ToString(), newDir);
                    continue;
                }
                Debug.Fail($"Error! {line} not recognized as command!");
            }

            Console.WriteLine("Finished all commands! Filetree now looks like this:");
            Console.WriteLine(root.GetListing());

            Console.WriteLine("Checking sizes of all directories...");
            long maxDriveCapacity = 70000000;
            long freeSpaceNeeded = 30000000;
            long usedSpace = root.GetTotalSize(true);
            long freeSpace = maxDriveCapacity - usedSpace;
            long spaceThatINeedToDelete = freeSpaceNeeded - (freeSpace);
            Console.WriteLine($"{usedSpace}/{maxDriveCapacity} elfbytes used, need to free {spaceThatINeedToDelete} for the update!");
            ElfDirectory bestDeletionCandidate = null;

            long smallDirectoryThreshold = 100000;
            long sumOfTotalQualifyingSizes = 0;
            foreach(ElfDirectory dir in allDirectories.Values)
            {
                long dirSize = dir.GetTotalSize();
                //Console.WriteLine($"Directory {dir.ToString()} has a size of {dirSize}");
                if(dirSize <= smallDirectoryThreshold)
                {
                    sumOfTotalQualifyingSizes += dirSize;
                    //Console.WriteLine("Ding ding ding! This is at 100000 or under! Sum is now {0}", sumOfTotalQualifyingSizes);
                }
                if(dirSize > spaceThatINeedToDelete)
                {
                    if(bestDeletionCandidate == null || dirSize < bestDeletionCandidate.GetTotalSize(true))
                    {
                        bestDeletionCandidate = dir;
                    }
                }
            }
            Console.WriteLine("Sum of all directories under {0}: {1}", smallDirectoryThreshold, sumOfTotalQualifyingSizes);
            Console.WriteLine($"Smallest deletion candidate: {bestDeletionCandidate.ToString()}, with a size of {bestDeletionCandidate.GetTotalSize()}. Directory listing as follows:");
            Console.WriteLine(bestDeletionCandidate.GetListing());
        }
    }
}

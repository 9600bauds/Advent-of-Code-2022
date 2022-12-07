using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day3
    {
        //https://adventofcode.com/2022/day/3

        class Rucksack
        {
            public String compartment1;
            public String compartment2;
            public List<char> itemTypesContained = new List<char>(); //Does not include repeats.

            public Rucksack(string compartment1, string compartment2)
            {
                this.compartment1 = compartment1;
                this.compartment2 = compartment2;
            }
        }

        public static string allChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static long itemToValue(char item)
        {
            return allChars.IndexOf(item) + 1;
        }

        public static void Run()
        {
            //String input = "vJrwpWtwJgWrhcsFMMfFFhFp\r\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\r\nPmmdzqPrVvPwwTWBwg\r\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\r\nttgJtRGJQctTZtZT\r\nCrZsJsPPZsGzwwsLwLmpwMDw";
            String input = "NGvdqJmJvpNbGRMGQgRsfgfn\r\nWlHTHShlLwSWjFRsncfbcwsgQc\r\nBHtSBHWHSCWLZHlhjTHLLdbNNqNpzpDzNvDvtPmmPp\r\nJJSShnTpDSJJlllfwBNVbMQWwhQhgQtt\r\ncTzrvrHdLwwzttQNWB\r\nqrFqTFvqZvrmsplsjlnDflnZ\r\nmhhhVHvNNddHMwBqQwlWZZtv\r\nfbjzjJllCtWjjrZtjq\r\nCbgcgpPRDJfzVHFFnSnsSDlm\r\nZqBPqBQnPLmqZsFqhsvFsLZQMfSSMbbWddWbjbJSrgWgJf\r\nNRHnlllcDwwCNClNtttHbNJrSJNfbdWMdfbWgdrJ\r\ncHGlzTptHtCpncHnCpHpRGzDmvVhqLmvLPmPvLqPmzsqqmPB\r\nrCzVtMMbMvCmmvGlclFQFfLpJFJfJpcLHPJL\r\nnDGGwqGqnRTfpHLpRFpLFf\r\nZNdNTDsWgNZsZBndnGrzrlMrjgrmjVGjvC\r\nMgFZHFTgqFFDZZDTdVdHrzQvLzCGwpCPrGLqQpzz\r\nJsnmbjhmffJbRNJppzPPzwzzrwdv\r\nlfblfthBRbBRjnjhBtBlZgdVcFSTVFDtSSWgMcdM\r\nhPVhVhWPCMhlDTTWdrPlTcLjfbZbFNjZBbFNBbdBFbsB\r\nMHSwMJpHnqJHwtqHGqGGmvqZsZFjBmsBNRBFfLbsFsZfsZ\r\npqtMHHQpvqnwMpgJMCChTQhVVlclPWrCCD\r\nzRBBhZFwWZlBQpMZNNNJsfDpLsNsJppN\r\nSvggPbjvVSvvtgGVPbbnSMcCLtMrDddssJdsLdfdCD\r\nmTSmMgHjgmgGgqzTwZwBlBFzwB\r\nWLzWZHWSZPFRVSPSPM\r\nhmrvmGvfTCmhBGBqTfnmJFfdbQcwdMhMwRdbQMVQQcMhsQ\r\nJGJJnrnnCmqBTJTrNBqBLDzHFLFDNgjZlWtDNZHL\r\nbwbbnWwpbTwFHwRzzzmH\r\nZccjZjddjPVhJmrBQHHFQRHcWF\r\nNVhWldsMjZZZLSnvSTGTgvMb\r\nccJbHpzccZJsNpJCmHHlBTgHnlTPmF\r\nqvQGQfDVhhDfvVfVDSdDCbFnjmllPQjlbCmnFgjg\r\nhSbtWRGvhdfDVdVRfvRNpsWsZLNMZzcswLZWMM\r\nvlTdlBTMdtjcvLGmtb\r\nSSgfSsJngCSSwNFgspHFNFFpjlbGjQbbQGLthLnWtmWWhjbm\r\nSJsfqqgfNHwJfHgCpwzBZVMDBPMMRPTlqzBr\r\nVHsVhtbRHRpVHBfBCJdNfGjggGJdqLGq\r\nwSzSrrSMPDSDwzPjdqJjNwGdsLqGjj\r\nMnrnQTnWZWWzWQDMvZhtHtshhHlHBcBBsvVt\r\nDZbPqdTqGTZtRrzjFmZZtF\r\ngjQwVvBVWgfghvgmcrBNFccHFRmHtF\r\nQlgvWlfgVsQfdlqqjqPDbPlM\r\nVcfLwwcMlpnfVDrDtrtvbjMtTM\r\nmmgBgzSQmQdgHBFSLvvbDTJmTDvTJJDr\r\nRWNBHHzWNSdSdzFgSLNWWfZGwfpcwWVnnfpCCWlV\r\nGDZLtsJMFGLDPnbblJlNJNcJ\r\nBBRgSwqwqRZhTVSqjVgRwCdQcmcPmdnPPnPnmjlrbmQj\r\nRCqfVvhfCCShBCRfVCwztDGZMHpLWHftFptspF\r\ndlZqlBfBSShZhvprbCJTDrJCJjJNDh\r\nWGRwQwHsMVVGMsVGcRVtQWRVpNCjWNDbzbDNJnbnrCbprrNW\r\nHgHRRVGGwLgLBPvgSp\r\nQPlZSlZzVLLDwhDfBppf\r\nbghGGhmqrspDcfbsbs\r\ntTrdTgFddtnvmdgvtCTdGTTqFZjjQQPVZPSZSjlZhVVQjlRS\r\nBgBFHnwwSTNHqSPN\r\nGJmCbDdlbZGCLhsstNLsMZZZ\r\nJGJpCCDvmlVDVldGJBVfBBRwRjnVWWBRfN\r\nWTFWQgGQtTMqMCJJzDVDgCchhj\r\nmNPBmPlPHrWmwmNLHmShcnJjhrnzJzdcdzdjJJ\r\nSHssNRSmvPRmlsmLwwsmwLvpQptpQWMQbGFQFtfpFfZQ\r\nDgpNLVjgNjjmzGPVRmfrZrctdTcrzfwzdfMc\r\nbnbNqnbFNwMcMtMfwF\r\nsvCQHHhShnbCvHChsvHlLDVhJJLRJGNpgPJPjLLD\r\nTmBzgTVVBgfbmTVfPmFRJcHctnHDLDDLJqqBGB\r\nhwvlNCCvSphMwSvrlwCCrrDcfRlJDLRtGqcqHnqRqLGR\r\npMSSMMNCSwMjjWhwrrjShQNFmsPmPFWbbZzVfZsPPPZVmZ\r\nsTTrWGCMggpVWhSBltWp\r\nHNJdwLDzNcJnNLwJJPqpllqhBpqStjfwlfpj\r\nPJHzDzFLtLccdLggvrGGmgvFssgG\r\nFwCssBFRBlvbBVdQ\r\njPzjDpqNGqJzZGSNHppPclFvvdfVflblbJlmFfll\r\nSDzDpSNqjZjjZFSrHrFZTTCMLsnTLnnnMhrLtLnn\r\nScWQvvSDddGrWVrG\r\nfwhPFLpwTfTjrzwHdmmmGdgdsPsqdRmV\r\nCHlFpTpwwCjwFjwjCBnrvQBZZcBSnZtvZl\r\nvJvdWVNslWtJcDtDHrDf\r\nGCnnMZpZnSZpvDqFtftfjfZqrh\r\nTbGMSRCRvWbPNsWB\r\nNNNdsRddGNdZZTCBtqbtBgtC\r\nzhFHppHhzcgmzQhccjgmjhQTnvvBFtBnCBbbnTvtCCtntt\r\nHpjmhfSjQwfzwHmcggfzjSLfVWPDsWMsMdWdDSMsGWPPllVN\r\nWSvcSSwrGzFsznqPNNWqPqlllB\r\ndjVDdHdSPRqlntjN\r\nLpZZgpLgLHTDHVpDSTsffvGwrcfffGwv\r\nwGlbWGVvGlWlrvppbFMjQjsBjCsjmCzzQzNv\r\nZgfdJcfZhMNCgSBRCQRz\r\nhcLDZPZdqZhJPhcTHJfPHVqlqtFWMrGGrpwVGVpWrV\r\ndsngCgdssHDVsHdsFDvMDvmMmjTjDFTL\r\nqZpSqptZZGWLTLSjlLHFzl\r\nNZqqRpWqhQpNhqhpZRWBJQQssJbbCsdbHsCbgb\r\nQdGBjjbHsBsBbBdGcwwTGrCRRrFcPPTC\r\nZDtvWfMDvWScSrpzPccCdr\r\nhhZMgffDhZNvtDgHQsQQVQmBVVHNdV\r\nLhQLrzVdVmqcjmTNzm\r\ntHMZDJDZCDDtZMWwCJjcffqqfjRmqSRqcq\r\nCpHpZZWWtWpWwBplZWmQbhVBVPhnPrhbLQPvvs\r\nFFgFSmJmSgGpZzsmgGmbDlDzMQPDNPzRQRDjQQzV\r\nCLwnwWBdrtthttTWBWdPnVvRVVVNMSVQPvVnnV\r\nBTtdLthfhTrLdftCwqrddmGFcSfpGbsmFGHpmGFHHc\r\nJFJnMZwQBqnJJBqZJqPqMFBlbmBHblWbrmlfbWgbvmWrgW\r\nspCTjtVzsNDdsNdTsjVTtNzgHfmWWgHSSrgrbSbbhHbVHS\r\nTfCdjjsjzLNsfTszcdqcQMnRMPPRnFRPQRFP\r\nVvDgDqTDtTNWTWfNFWlW\r\npzPvdssRNQFQRNZF\r\nCCpBpsrrccGvttgGqBDG\r\njmZrrjlCJqmCVFMPbFbBZPVp\r\ndfLLfRMGTdHbssPLLPbFwL\r\nQWWHHTRQdRRHRMhzWQfvddngqJqjjNgqqjlgvrtjJmtn\r\nsGGwJdHDDTfWbTcRzbbz\r\nBmjvdhNVlFBZmSZvFrWpfpcBrbzbWcbqpf\r\nSLmSZLhNhMhwtLswPHGssd\r\nmGhlPclTmhhlJRWlRTDPlJtTFMngBcLSBHHBHLHSwncFgLwB\r\njQVbjprjVfzbZQrzdGnHrrBLgSGwGFLHHg\r\nzzZqjQjdvsRlGqThGJ\r\nGSPQPvVmSwpVQGVlSQmWJRcFBpnFBcBWcJcJDc\r\nrTTCLmhTTbZNqMNbhjfhmDzsFDWzsDnfcBWDDDzcFs\r\nqmjhrhCtbMCZNhZMhNTZbLjvQdHdHGgwgdtQHlllQwlQgv\r\nggpCCgvjPTJWjBjWWJgCWCdVVHRZdLfZhqLdZRHZrf\r\nGsstmNslzzzGlMnGMnVZRZrLpZqdhZHZrZHM\r\nlNbDsbltmzpsmmmnnccBJTwPgWvvvTwPwFPS\r\nFWbTRTdWGCnThqQVBQqJ\r\nrrDMPrDcSrvtcJdLVhVHQMQVBQ\r\nrNtNwrZtDNPmZStwvcvRlGFRlzCRlpmdpplbpb\r\ngHrHrlFgjCrNDfCMTzwwLN\r\nWhvTvvWnmQvpGWNNLzwWfNzW\r\nvTnRZhnRRBhscBVpcBTvnsjFltPqggqHPHHjHrPcgrFg\r\nVzfWRVsnNzWfsvpQPvvFbdVQpQ\r\nSqCqqhLDTTCTTCDcSdbpPvdPFFvhMbdMvF\r\nBCLBDCDGLlTClCSrglrGzWmrszzmHRJmfJfJpHNz\r\ndwGBHGdwdcCMCBzzZJJssZFsBBgt\r\nNRqbRbQhLQRLrQlTggFWlZtRlTvW\r\nFbNDFDLqnmLmNbqbLQbhLNDpPcVHMSVMwCVHcPnVGccwjdcM\r\nLdHtrrrHrLZrBVbQjtPnnsVb\r\nTwfhhcTCTCpfJJwpTJwhDDPnbGsbFjlQnnQjFBFslsBQDl\r\npwJCThfRCMMMvhchhwHSmWLZHLNHMdrdZzPg\r\nLbMQbHbHQLLMsWLvszvzvqCfqCCqss\r\nScWlpmplWrDzlzvznJ\r\nRNNcZWhSZmdVdPwHbQQTTwNwjP\r\njFFFtHZjwmLNmnQCFL\r\nsVbdsqcqHBHqrQrLPmWqQnmr\r\nsfGJVVzJJsczczfsczBzzvdbTMTptlTZZgDSDtGlplZSlgHt\r\nMgMQJdqqMDQJDggzTMgVplvffmctcCzmfjRlmmmjjR\r\nHrGbGswnBBtRvccBlljB\r\nHZPHRRGGshZHnnnwPnshnVZqMJJDdpQDVgDdVDWDpQ\r\nwhwQRQGHRVhWRRcLLJgLmL\r\njSnnzgBnpCZdCBjNmnNNJmllJTlccT\r\njPSzrzpzpCjgfZZrZCFpdwQDQVVPttGDtVqQVtHqth\r\nmvnGFmvGhTcSCBcBpv\r\nbwMRzbQLwBQRWSctCcTtLpss\r\nJJgHZqRrbqDnmBjhDh\r\nMVvvGrsbGtVsgTggHjSFHJBBBg\r\nPPNpCpQPZppplttDNwZPBdfTFPPTSBWSFjjSTH\r\nCpNwChQCzDDNZwhZlpwZpqrqsGGsmmctGbbbzcmMms\r\npjMbgCgdQjCgBjQQCncwcGGLDZvFtGLsZZFZtH\r\nzPhhrVhVVSmqVqhmzPqvDtsLLHrFWFvGFGFsvt\r\nSVPzVTzJNBfjDQbQTb\r\nCRDjjRmmLhjRFFChmHDNLZzsZNnPZNzlnnsvlv\r\nSSqcMwdrctQVtqTwSSgnvZnsZvnBZpcPsvlvbz\r\ntrMGSSVdQQqdGMtwwQCmRHHhmJFhsfJGfjHh\r\nphJzrnJJwNNSJhSnwpwGGZzmvNfmmDvfcvcDfvbRPNcvvR\r\ntWtgQBqsqdLFLmZvTRTfDZcb\r\nttssdgQqsHQtZFsqVdgdgdCBJGSphnljnJhjwrhnpJrrzJHl\r\nsrzpVWrWTptbrPpPPtcWpNhNNNdfhhDgDNvfBDNNds\r\njmnQHmLqlnSlGMjqnLLljRHqdNdgwHZBgfhZvBdNhDwBhhtZ\r\nMjSlnLmMLnCGjlSQLVWCzbrcTpPtpFbFWr\r\nZnQRczHZsMSRZQcBRSZRscQwJbWFbbQwpWTjdFLJTJTWwd\r\nPVmGqDlGhDPVNvqDmmqtqLbbpJfFJwpbdJpdbfdjwdbl\r\nVGNCgGPgqVqhNvmNCNZnSsRLRsMzzgBRnHrS\r\nZgMMgJMhjmZrZgggmlTTbfwTfRfbRGwlGTDf\r\nnPqQttNVPzSPnqpGDwDDbGfwbJ\r\ndJvQzzJtdSPWSthhHMjgMvrHghsv\r\ncMvwHCWcMnwWnScWVFzTqHpHFpVBFtFp\r\nbbblgRDhtlGgRPFBRqFpmzVFBTFp\r\nfPbtGJGhfDfDsPhQJDPbbnjjSWnwjdvQCnSSCnCSCM\r\nNcgDtwghTLntgNtLrjfHSSFlSbCfprlL\r\nZGGMmdmVZVvsRQvMGRVVZCHPfpZSfZbFPlbPjCfH\r\nRVRjvRzMQQJBVmzzgWgzTWTWhNcWzN\r\ngsgBqdsWprWddpBghBpwwJzbLcvhCZmwZCFcJC\r\nPRPtStHfwmJvzPmF\r\nHnSHHRQDVFsVVgsgTWsG\r\nQRQTRrDHSLSNzzZLzZ\r\ndBmPwfwffWtWRtzdhhLzLzLzzLFN\r\nBtWnWCCVBWtCBmRPqVmqmntjjlJHJslJQVsQjsbbHrjHDQ\r\nTwwJrHSMnHGvWHMvvSqrrZbRrRqfqVNfbNRc\r\nGjhstmPFFhlFtmmjQtlgVcZVfcgqqNRNpgRcbP\r\nCzdCdFCtdzGWGJwWWHdW\r\nzfSVfSpHVpCHSZLnsttDnvDvpcsqRc\r\nrWzMGWFFPBFjqjDjFDFs\r\nPbQQWbJPrQwPrrPBwrJCVzZZLZdLSLLmfZfHJd\r\ngPDPLgsLNslNLHqlLqqjhjnwwjJbDjnjwTRnGD\r\ntzdMdMddmcRMdtcFFGWnwWjFwjFhGbTG\r\nmRMmttpVHNCNpNZN\r\nmfCFGfDDFCDWtvvstjjJ\r\nnjnVnrggLlwVVqLpvHVpMpMsHVhhMW\r\nQQPPPnjlPPSgwBrnNLcdFCNNGFbmbZFcZzFf\r\nNzNHFNFnFrtgwwPchvGFFS\r\nLsjdQCVsTsLCTTdMCJtQgPPqwhPgqScPGvSZ\r\njdLdVjJtCVjRCMpmpNfNNWHrNzDrNrHrmr\r\nNmggPPrPbPmdCbcfCNLVRRWpWTWRVTpdVVWspW\r\nqGhDzGqnwGQnJrjllJWttMRDFRtMVsTDTTZs\r\nSrnHhGQlvLmSfbfc\r\nDmdPCJMLlQdSjGCqjcGGccHH\r\nzWtBwfsgvVnBfftWtnnpTmnTRhppHpTqpc\r\nwzFtwZWmsVFzZtvPJSPbMFJFDJJJJd\r\nwrPRRSJSWrTSRzRWrqlfCLlcBfBGDqrL\r\ngVNQjgdVhdfqqhlDCBDs\r\nNmjgbtmNtjNnjbPbvRJPbpwZwZSD\r\ntNHGccGNthtSGmVjjVmrrVPqSB\r\nfgDTwRwDFmLTFlspBBqjjBgqBssB\r\nmLCZwZRMJMbtdWMtvd\r\nTPzHPPgChjsgPdPTjQvZLvnpLQnvlRQn\r\nGScFSzFWWrfGGMrVFMqGqmrBnplmwmnlZZlmnvvvLRnJLLvJ\r\nqVSVFtFtFtSzrTNNDsHhhNTHht\r\nNQqtqmqmNhvvclvhcljJ\r\nCSCfMZSgWMvfWgrbjwcMJwrrrclr\r\nCGSCZgSGZPRTSCWWDgGBRtnFRvqNRsLLzmsLzqpq\r\ntWmtCZjnWZWCGjtnnmtcwFvvlgSDTDTvVwsVgCfT\r\nLpLhpLdqbBMNsQPBQhpLvgFqllgfllvVvwTDTwlw\r\npNQBBdLbBPpPHLmGsRWjRZJzWZHc\r\nWtjBSvBjWzTtzvDTjBfbbthsMNRNgCMQDgRcCcQwLRgCQgNc\r\nHJmqnHqHpplVnlPdqGrpGQNLCgSwLMwFwFFCgnMLRw\r\nSdJGpHVZmqpVVVdZVJGddsjvzzvZTsZvWTbvszWjWj\r\nFhRhhLZgLZhCRWZBFFWRmGbvSgHqvvbPvHTPccVncb\r\nwzSMpjJdwssdrdDfJJJsJSvpGVPqGpvVqTVqTnccnTvH\r\nrwfMMdtDjNwjzDrjDDdtChRZWSWhmCWBSmLQRW\r\nRWLNLWrhtrhWJmLnSStBBdVtBGVVBt\r\nwQqnzjCFbflqpQlQFTDDGGsGDBZBSZMsDVfG\r\nQvqCTwjjTqwbTqjznFzQvqjFJgmvgghJgPmgmvPNmNRJJNgN\r\nqLqwhztjhqqDDzjZqqjPMmFmCnVDsmgbggggTMDC\r\nWBhWJQrJcRmnFnWMTTCF\r\nlvvJSlGSvBvJQBrcpSfwwLjLPjLfhptjwNtp\r\nsbFjnZpPPGZLZzCRhqbJhJMCqMgS\r\nvtNvFHBcNwNDHffvtfQMSMJVRMBMChVqSMCBJV\r\ncQlvTffDlFWTlcfFTlHQNtzzGGWGdLsGWdrnzspjGdGr\r\nLMQtlzlMQLLrztVfVdfqDdrhrhdd\r\nJPJTHcvPTPTJGPZgbmvGPmcZhwRVdDBdSWfdRHSBfqBSVHqq\r\nsJchPZGccmcbvcmgmPcCnnnnpzppQppspFjQntMl\r\nqtQQtsMDqtPDGQltPHbsLFnMccRNcVLLrVNVwMVM\r\nLCSdzZdBZmvzZTCBfJrwnWppFcWrFpdRnWpR\r\nThSgBZTLJmPHlgQHjPtq\r\nmrwGPrVrbjbPVmwmbdTwbGfJMDJMgsqhhDjsqjJppfqt\r\nSQnLnWnWHLSFCRnlQRnFhqfsDMJMppqDfcWgpDfD\r\nNCSvLQnRSQFBLBzdgvTbbwPrzbPZ\r\nFFjvvHZbHZnZpvFHZcFbgQVwgwQnJfQPVNQJGqSq\r\nRWmCmdClRtTzVRwVfVQPNQgN\r\nshwhzTsmlbhZDLbBHL\r\nPpPHllshHDTlsprJrsPQpltzjVzjLNggZNznLNLnhNnnjL\r\nqRBvSwqBdRqvmfvCRSSLjcnVcVmLgmnNZjmQVg\r\nvdfbSfBWffMbQqQdtprtslHJsWDGHptt\r\npqQdFWlQZpGZpLpS\r\nwnjwJhjvVgjwvwvsgwgtsRTtssGTtLrNtrSrHS\r\nVDJVMGCCChjccDJDwgwVJvMBzBfzbzbDPPFBFBbffzbQqq\r\ngBwwBZGhcfhnFjvrQjMhrjQQ\r\nPPLJNdNldlNSRmzLSlpbHQvbvdMtjjbMtMtt\r\nlqDJmlSmlmPzqNmzmVnvnBZDgvBWgcZTfD\r\nHMqrwWqzWJqHzrjgGFNNtQFMFQnFBt\r\nLddPLdVmchPSvmcvTZlvghLLFBDNDtFGDQpRnntnFDQnFPnB\r\nSbSvZTSLSgqbCHJWzr\r\nTGcjzjgtNqjttgNNTTjmGwLhfQQfDnDLDwSQWTSCvh\r\nPHJRJJbBVMPRMJHbJRMPbwCQSSvfCDhVhvvwwvQLnW\r\nZJPMbHbJJJsdsJplRRRZsPJztrFrqtzGrgmcrprcmFjDgN\r\ntlDpSbpwgbgtpddJppgJwJDtNQWGQlcGQGhlhnGGWcrcWWFr\r\nMTZLqzjfFLqLjRfvqsQhNPGnhGGsnchW\r\nLMCzjzMTTjjFRfZMBTCvRfLRDDbVVpSbSgwwwtSBSSDJgStg\r\nZLVTrJmJDHFtzSTlpc\r\nwNhhNfhvwwvvfvPnsNPhglszqpcHcFbbFSzSzzCHzb\r\nNWjPwgNgRHGWvhwWPfgfGwjMDQJdQLVLJLQVVLRdBRJrZr\r\nCPRJCFJTqZfJlJRqssHJftCWQMnHHwMbbngMMrQMgMWwQn\r\nBmzVVhvvcvDdWgwVrTnrMb\r\nBjzvhjLLczzBjLchDLmLJtsCqFClTqsZCPtPTCjq\r\nDbWjNCWQCRRNsDPpFGcjjcqFqFfm\r\nPZdMSzSZTtZZqVmpqmmmTpgg\r\nZvZMzBztzvhvddPMQlNCQDbQLBLrsRRW\r\nWzWFhHpWhvCpPpPLswMHswMMHLbgmH\r\nNNZSZTVQNrTnqDqrrwtwwLstsMGMnbntGm\r\nTBmQcrNqNSQVmrmQBPdpFFzhFlPzzCPF\r\nnBgmSrjgmjtmrbjSFGLWtLVpFVQQVGFL\r\nJlChvCzvqCqWffwFdFVQfPVPHPFGLV\r\nJzvTThZcCCMcMMwJzlbjTjmnRgRTTBnWgbBn\r\nrppjbbDpGnwrGprVCLLJZDzQqZzLNQqc\r\nhtflFBFmBBlWTTgsggtZHMQLCCCcHqHMfZczHq\r\ngFdFTWgRhBmWWTFSGQbVnSSPnvndpv\r\nqFSRRGGgTgThTQhcllCWCJCctWWhfJ\r\nbvbdzNDMzHZNNHFHfJWWjljWNNfcnWtn\r\nPdbPdPBHmsdbdbPdBHBdmdmsgrTqsGQRTwSpSFrqrRSFpRwp\r\npQJZZGQtChQtpWZQTTWhNtVdVWSLBrsLSVrLvrvrLdBd\r\nlMHnzGRgPRMSMBLcvBSS\r\nnglFzflzHRDGgzfzPgHRbTDQthbZbhhppNbbCqhb\r\njVrvrJjpZfZCCGctwhbhMRcM\r\nBQQnFFTBdBndzssFsdTbRwDGTPGbcMbwtDgbcG\r\nHnLtQQBLtWNrVpqjJvWN\r\ndnVlsnJlMqnlNqJdnMRvDHBRvbBLHLpRSPPPRS\r\nNcGGCthFwcFwmjCTGDSfPSSHSPfPtDHfbD\r\nzNWNZGWNzQnWlJWVJn\r\ntMGSBtRtvjFcGpQrQQQQrp\r\nFffbJTJfPLNbTnJJmlVcQVfpQmlWVVfH\r\nFTdJJdhNvZhMtRSh\r\npSTfMtMLSTPsPsBszP\r\njdlmlFHHhVdmVHFNFRnHzHQJsGZBJbbJDvsDRPBsrGrDrJ\r\nVHnFjcdccjlmNVmnzmNVmCMggfqwtLLfSMwWtcWMSg";
            List<String> inputPerLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            List<Rucksack> rucksacks = new List<Rucksack>();
            for (int i = 0; i < inputPerLine.Count; i++)
            {
                String line = inputPerLine[i];
                String compartment1 = line.Substring(0, line.Length / 2);
                String compartment2 = line.Substring(line.Length / 2);
                Rucksack thisRucksack = new Rucksack(compartment1, compartment2);
                rucksacks.Add(thisRucksack);
                char[] itemTypesContained = line.ToCharArray();
                foreach(char item in itemTypesContained)
                {
                    if (!thisRucksack.itemTypesContained.Contains(item))
                    {
                        thisRucksack.itemTypesContained.Add(item);
                    }
                }
            }

            long totalScore = 0;
            foreach(Rucksack rucksack in rucksacks)
            {
                //Console.WriteLine("Rucksack containing: {0} on left compartment, {1} on right compartment.", rucksack.compartment1, rucksack.compartment2);
                char[] items = rucksack.compartment1.ToCharArray();
                foreach(char item in items)
                {
                    if (rucksack.compartment2.Contains(item))
                    {
                        //Console.WriteLine("Rucksack contains {0} twice! This is worth: {1}", item, itemToValue(item));
                        totalScore += itemToValue(item);
                        break;
                    }
                }
            }
            Console.WriteLine("Total score: {0}", totalScore);

            long badgeScore = 0;
            long group = 0;
            Dictionary<char, int> instancesOfItemInGroup = new Dictionary<char, int>();
            for (int i = 0; i < rucksacks.Count; i++)
            {
                Rucksack rucksack = rucksacks[i];
                foreach (char item in rucksack.itemTypesContained)
                {
                    if (!instancesOfItemInGroup.ContainsKey(item))
                    {
                        instancesOfItemInGroup[item] = 0;
                    }
                    instancesOfItemInGroup[item]++;
                }
                if (i % 3 == 2)
                {
                    group++;
                    Console.WriteLine("Evaluating group {0}...", group);
                    foreach (var entry in instancesOfItemInGroup)
                    {
                        if (entry.Value == 3)
                        {
                            Console.WriteLine("{0} is group {1}'s badge, which is worth {2}!", entry.Key, group, itemToValue(entry.Key));
                            badgeScore += itemToValue(entry.Key);
                        }
                    }
                    instancesOfItemInGroup = new Dictionary<char, int>();
                }
            }
            Console.WriteLine("Sum of all badges: {0}", badgeScore);
        }
    }
}
